import { alpha } from "@mui/system";
import {
  Box,
  CircularProgress,
  Collapse,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Typography,
} from "@mui/material";
import SpaceDashboardIcon from "@mui/icons-material/SpaceDashboard";
import SummarizeIcon from "@mui/icons-material/Summarize";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import { ExpandLess, ExpandMore } from "@mui/icons-material";
import RoutingConstants from "../../routing/RoutingConstants";
import React from "react";
import { useGetProjectsQuery } from "../slices/getProjects/getProjects";
import { useNavigate } from "react-router-dom";

const Sidebar = () => {
  const [open, setOpen] = React.useState(false);
  const { data: projectData, isLoading: projectsLoading } =
    useGetProjectsQuery();
  const navigate = useNavigate();

  return (
    <Box
      sx={{
        height: "100%",
        width: "20%",
        display: "flex",
        flexDirection: "column",
        justifyContent: "flex-start",
        alignItems: "flex-start",
        bgcolor: (theme) => alpha("#e3d6d5", 0.3),
        backdropFilter: "blur(10px)",
      }}
    >
      <List
        sx={{ width: "100%", maxWidth: 360, color: "white" }}
        component="nav"
        aria-labelledby="nested-list-subheader"
        subheader={
          <Typography
            color="white"
            variant="h4"
            gutterBottom
            sx={{ mt: 5, mb: 5, ml: 4 }}
          >
            MyTask
          </Typography>
        }
      >
        <ListItemButton>
          <ListItemIcon>
            <SpaceDashboardIcon sx={{ color: "white" }} />
          </ListItemIcon>
          <ListItemText
            primary="Dashboard"
            onClick={() => navigate(`${RoutingConstants.dashboard}`)}
          />
        </ListItemButton>
        <ListItemButton>
          <ListItemIcon>
            <SummarizeIcon sx={{ color: "white" }} />
          </ListItemIcon>
          <ListItemText primary="Reports" />
        </ListItemButton>
        <ListItemButton onClick={() => setOpen(!open)}>
          <ListItemIcon>
            <AccountTreeIcon sx={{ color: "white" }} />
          </ListItemIcon>
          <ListItemText primary="Projects" />
          {open ? <ExpandLess /> : <ExpandMore />}
        </ListItemButton>
        <Collapse in={open} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {projectsLoading ? (
              <CircularProgress />
            ) : (
              projectData.map((project) => (
                <ListItemButton sx={{ pl: 4 }}>
                  <ListItemIcon>
                    <AccountTreeIcon sx={{ color: "white" }} />
                  </ListItemIcon>
                  <ListItemText
                    key={project.id}
                    primary={project.name}
                    onClick={() => navigate(`${RoutingConstants.projects}`)}
                  />
                </ListItemButton>
              ))
            )}
          </List>
        </Collapse>
      </List>
    </Box>
  );
};

export default Sidebar;
