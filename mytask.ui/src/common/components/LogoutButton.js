import LogoutIcon from "@mui/icons-material/Logout";
import { IconButton, Tooltip } from "@mui/material";
import { RemoveToken } from "../services/cookieService";
import { useNavigate } from "react-router-dom";
import RoutingConstants from "../../routing/RoutingConstants";
import { useAlertService } from "../services/alertSetter";

const LogoutButton = () => {
  const navigate = useNavigate();
  const alertService = useAlertService();
  const onLogout = () => {
    navigate(RoutingConstants.login);
    RemoveToken();
    alertService.setAlert(true, "success", "You have successfully logged out");
  };

  return (
    <Tooltip
      title="Logout"
      sx={{
        position: "absolute",
        top: 25,
        right: 25,
        color: "white",
      }}
    >
      <IconButton onClick={(e) => onLogout()}>
        <LogoutIcon />
      </IconButton>
    </Tooltip>
  );
};

export default LogoutButton;
