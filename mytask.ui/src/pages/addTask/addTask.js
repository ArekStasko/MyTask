import {
  Backdrop,
  CircularProgress,
  Container,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import { FormProvider, useForm } from "react-hook-form";
import InputAdornment from "@mui/material/InputAdornment";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import CardActions from "@mui/material/CardActions";
import Button from "@mui/material/Button";
import RoutingPaths from "../../routing/RoutingConstants";
import * as React from "react";
import { useNavigate } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import validations from "../../common/validations/validations";
import { useState } from "react";
import { useGetProjectsQuery } from "../../common/slices/getProjects/getProjects";

const AddTask = () => {
  const { data: projectData, isLoading: projectsLoading } =
    useGetProjectsQuery();
  const navigate = useNavigate();

  const methods = useForm({
    mode: "onChange",
    resolver: yupResolver(validations.addTaskSchema),
  });

  const {
    trigger,
    setValue,
    register,
    formState: { errors },
  } = methods;

  const areFieldsCorrect = () => {
    const name = methods.getValues("name");
    const project = methods.getValues("project");
    const description = methods.getValues("description");
    console.log(`project: ${project}`);
    if (
      name === undefined ||
      project === undefined ||
      description === undefined
    )
      return false;
    if (Object.keys(errors).length !== 0) return false;
    return true;
  };

  const handleChange = (e) => {
    const {
      target: { value, id },
    } = e;

    setValue(id, value);
    trigger(id);
  };

  const handleSelectChange = (e) => {
    const {
      target: { value },
    } = e;
    console.log(value);
    console.log(e);

    setValue("project", projectData[value]);
    trigger("project");
  };

  return (
    <Container
      sx={{
        width: "100%",
        height: "100%",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      {projectsLoading ? (
        <Backdrop
          sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
          open={projectsLoading}
        >
          <CircularProgress color="inherit" />
        </Backdrop>
      ) : (
        <Card variant="outlined">
          <CardContent>
            <Typography variant="h5" component="div">
              Add new Task
            </Typography>
            <Typography
              sx={{ fontSize: 14 }}
              color="text.secondary"
              gutterBottom
            >
              Fill the form and submit to create new task
            </Typography>
            <Box sx={{ p: 4 }}>
              <FormProvider {...methods}>
                <TextField
                  color="primary"
                  id="name"
                  label="Task name"
                  variant="outlined"
                  error={!!errors.name}
                  helperText={errors?.name?.message}
                  onChange={(e) => handleChange(e)}
                  fullWidth
                  InputProps={{
                    startAdornment: (
                      <InputAdornment position="start">
                        <AccountTreeIcon color="primary" />
                      </InputAdornment>
                    ),
                  }}
                  sx={{
                    mb: 2,
                  }}
                />
                <Box sx={{ width: "100%", mb: 2 }}>
                  <InputLabel id="project-label">Project</InputLabel>
                  <Select
                    sx={{ width: "100%" }}
                    labelId="project-label"
                    name="project"
                    error={!!errors.project}
                    helperText={errors?.project?.message}
                    onChange={(e) => handleSelectChange(e)}
                  >
                    {projectData.map((project) => (
                      <MenuItem key={project.id} value={project.id}>
                        {project.name}
                      </MenuItem>
                    ))}
                  </Select>
                </Box>
                <TextField
                  sx={{ width: "100%" }}
                  error={!!errors.description}
                  helperText={errors?.description?.message}
                  id="description"
                  label="Description"
                  multiline
                  rows={5}
                  variant="filled"
                  onChange={(e) => handleChange(e)}
                  {...register("project")}
                />
              </FormProvider>
            </Box>
          </CardContent>
          <CardActions
            sx={{ display: "flex", justifyContent: "space-between" }}
          >
            <Button
              sx={{ m: 2 }}
              variant="outlined"
              size="medium"
              onClick={() => navigate(RoutingPaths.dashboard)}
            >
              Cancel
            </Button>
            <Button
              disabled={!areFieldsCorrect()}
              sx={{ m: 2 }}
              variant="outlined"
              size="medium"
            >
              Submit
            </Button>
          </CardActions>
        </Card>
      )}
    </Container>
  );
};

export default AddTask;
