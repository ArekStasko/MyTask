import * as React from "react";
import PropTypes from "prop-types";
import Button from "@mui/material/Button";
import Avatar from "@mui/material/Avatar";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import DialogTitle from "@mui/material/DialogTitle";
import Dialog from "@mui/material/Dialog";
import AddIcon from "@mui/icons-material/Add";
import { Box } from "@mui/material";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";

const DialogMenu = (props) => {
  const { onClose, selectedValue, open } = props;

  return (
    <Dialog onClose={() => onClose(selectedValue)} open={open}>
      <DialogTitle>Choose action</DialogTitle>
      <List sx={{ pt: 0 }}>
        <ListItem disableGutters>
          <ListItemButton
            autoFocus
            onClick={() => onClose(RoutingPaths.addProject)}
          >
            <ListItemAvatar>
              <Avatar>
                <AddIcon />
              </Avatar>
            </ListItemAvatar>
            <ListItemText primary="Add Project" />
          </ListItemButton>
        </ListItem>
        <ListItem disableGutters>
          <ListItemButton
            autoFocus
            onClick={() => onClose(RoutingPaths.addTask)}
          >
            <ListItemAvatar>
              <Avatar>
                <AddIcon />
              </Avatar>
            </ListItemAvatar>
            <ListItemText primary="Add Task" />
          </ListItemButton>
        </ListItem>
        <ListItem disableGutters>
          <ListItemButton
            autoFocus
            onClick={() => onClose(RoutingPaths.generateRaport)}
          >
            <ListItemAvatar>
              <Avatar>
                <AddIcon />
              </Avatar>
            </ListItemAvatar>
            <ListItemText primary="Generate Raport" />
          </ListItemButton>
        </ListItem>
      </List>
    </Dialog>
  );
};

const ActionsDialog = () => {
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate();
  const handleClose = (value) => {
    setOpen(false);
    navigate(value);
  };

  return (
    <Box sx={{ position: "absolute", top: 25, left: 25 }}>
      <Button size="large" variant="contained" onClick={() => setOpen(true)}>
        Actions
      </Button>
      <DialogMenu open={open} onClose={handleClose} />
    </Box>
  );
};

export default ActionsDialog;
