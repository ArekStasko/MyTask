import {
  CircularProgress,
  Collapse,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import { ExpandLess, ExpandMore } from "@mui/icons-material";
import RoutingConstants from "../../routing/RoutingConstants";
import React from "react";
import { useGetProjectsQuery } from "../slices/getProjects/getProjects";
import { useNavigate } from "react-router-dom";

const SidebarProjects = () => {
  const [openProjects, setOpenProjects] = React.useState(false);
  const { data: projectData, isLoading: projectsLoading } =
    useGetProjectsQuery();
  const navigate = useNavigate();

  if (projectsLoading) return <CircularProgress />;

  return (
    <>
      <ListItemButton
        disabled={projectData === undefined || projectData.length === 0}
        onClick={() => setOpenProjects(!openProjects)}
      >
        <ListItemIcon>
          <AccountTreeIcon sx={{ color: "white" }} />
        </ListItemIcon>
        <ListItemText primary="Projects" />
        {projectData?.length > 0 && (
          <>{openProjects ? <ExpandLess /> : <ExpandMore />}</>
        )}
      </ListItemButton>
      <Collapse in={openProjects} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          {projectData.map((project) => (
            <ListItemButton sx={{ pl: 4 }}>
              <ListItemIcon>
                <AccountTreeIcon sx={{ color: "white" }} />
              </ListItemIcon>
              <ListItemText
                key={project.id}
                primary={project.name}
                onClick={() =>
                  navigate(`${RoutingConstants.projects}/${project.id}`)
                }
              />
            </ListItemButton>
          ))}
        </List>
      </Collapse>
    </>
  );
};

export default SidebarProjects;
