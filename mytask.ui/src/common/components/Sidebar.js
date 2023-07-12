import { alpha } from "@mui/system";
import {
  Box,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Typography,
} from "@mui/material";
import SpaceDashboardIcon from "@mui/icons-material/SpaceDashboard";
import React from "react";
import { useNavigate } from "react-router-dom";
import RoutingConstants from "../../routing/RoutingConstants";
import SidebarRaports from "./SidebarRaports";
import SidebarProjects from "./SidebarProjects";
import ActionsDialog from "./ActionsDialog";

const Sidebar = () => {
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
        <SidebarRaports />
        <SidebarProjects />
      </List>
    </Box>
  );
};

export default Sidebar;
