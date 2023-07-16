import { Container, Link, TextField } from "@mui/material";
import * as React from "react";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import { FormProvider, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import validations from "../../common/validations/validations";
import InputAdornment from "@mui/material/InputAdornment";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";
const AddProject = () => {
  const navigate = useNavigate();

  const methods = useForm({
    mode: "onChange",
    resolver: yupResolver(validations.addProjectSchema),
  });

  const {
    trigger,
    setValue,
    formState: { errors },
  } = methods;

  const handleChange = (e) => {
    const {
      target: { value, id },
    } = e;
    setValue(id, value);
    trigger(id);
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
      <Card variant="outlined">
        <CardContent>
          <Typography variant="h5" component="div">
            Add new Project
          </Typography>
          <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
            Fill the form and submit to create new project
          </Typography>
          <Box sx={{ p: 4 }}>
            <FormProvider {...methods}>
              <TextField
                color="primary"
                id="name"
                label="Project name"
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
            </FormProvider>
          </Box>
        </CardContent>
        <CardActions sx={{ display: "flex", justifyContent: "space-between" }}>
          <Button
            sx={{ m: 2 }}
            variant="outlined"
            size="medium"
            onClick={() => navigate(RoutingPaths.dashboard)}
          >
            Cancel
          </Button>
          <Button sx={{ m: 2 }} variant="outlined" size="medium">
            Submit
          </Button>
        </CardActions>
      </Card>
    </Container>
  );
};

export default AddProject;
