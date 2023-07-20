import {
  CircularProgress,
  Collapse,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import SummarizeIcon from "@mui/icons-material/Summarize";
import { ExpandLess, ExpandMore } from "@mui/icons-material";
import RoutingConstants from "../../routing/RoutingConstants";
import React from "react";
import { useGetRaportsQuery } from "../slices/getRaports/getRaports";
import { useNavigate } from "react-router-dom";

const SidebarRaports = () => {
  const [openRaports, setOpenRaports] = React.useState(false);
  const { data: raportData, isLoading: raportLoading } = useGetRaportsQuery();
  const navigate = useNavigate();

  if (raportLoading) return <CircularProgress />;

  return (
    <>
      <ListItemButton
        disabled={raportData === undefined || raportData.length === 0}
        onClick={() => setOpenRaports(!openRaports)}
      >
        <ListItemIcon>
          <SummarizeIcon sx={{ color: "white" }} />
        </ListItemIcon>
        <ListItemText primary="Raports" />
        {raportData.length > 0 && (
          <>{openRaports ? <ExpandLess /> : <ExpandMore />}</>
        )}
      </ListItemButton>
      <Collapse in={openRaports} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          {raportData.map((raport) => (
            <ListItemButton sx={{ pl: 4 }}>
              <ListItemIcon>
                <SummarizeIcon sx={{ color: "white" }} />
              </ListItemIcon>
              <ListItemText
                key={raport.id}
                primary={raport.raportName}
                onClick={() =>
                  navigate(`${RoutingConstants.raports}/${raport.id}`)
                }
              />
            </ListItemButton>
          ))}
        </List>
      </Collapse>
    </>
  );
};

export default SidebarRaports;
