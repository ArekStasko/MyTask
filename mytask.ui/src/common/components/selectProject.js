import Box from "@mui/material/Box";
import {
  Backdrop,
  CircularProgress,
  InputLabel,
  MenuItem,
  Select,
} from "@mui/material";
import { Controller } from "react-hook-form";
import * as React from "react";
import { useGetProjectsQuery } from "../slices/getProjects/getProjects";

const SelectProject = ({ errors, control }) => {
  const { data: projectData, isLoading: projectsLoading } =
    useGetProjectsQuery();

  return (
    <Box sx={{ width: "100%", mb: 2 }}>
      {projectsLoading ? (
        <Backdrop
          sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
          open={projectsLoading}
        >
          <CircularProgress color="inherit" />
        </Backdrop>
      ) : (
        <>
          <InputLabel id="project-label">Project</InputLabel>
          <Controller
            render={({ field }) => (
              <Select
                {...field}
                error={!!errors.project}
                helperText={errors?.project?.message}
                labelId="project-label"
                sx={{ width: "100%" }}
              >
                {projectData.map((project) => (
                  <MenuItem key={project.id} value={project.id}>
                    {project.name}
                  </MenuItem>
                ))}
              </Select>
            )}
            name="project"
            control={control}
          />
        </>
      )}
    </Box>
  );
};

export default SelectProject;
