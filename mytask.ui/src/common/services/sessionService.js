import jwtDecode from "jwt-decode";
import React, { useEffect, useState } from "react";
import { GetToken } from "./cookieService";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";
import { useAlertService } from "./alertSetter";
import { Backdrop, CircularProgress } from "@mui/material";

const SessionService = (props) => {
  const [isLoading, setIsLoading] = useState(true);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const token = GetToken();
  const navigate = useNavigate();
  const alertService = useAlertService();

  const checkTokenValidity = async () => {
    if (token !== "undefined") {
      const decodedToken = jwtDecode(token);
      const currentTime = Date.now() / 1000;
      const tokenExpiration = decodedToken.exp;
      if (tokenExpiration < currentTime) {
        navigate(RoutingPaths.login);
        alertService.setAlert(true, "warning", "Session has expired");
      } else {
        setIsAuthenticated(true);
      }
    } else {
      navigate(RoutingPaths.register);
      alertService.setAlert(true, "warning", "You do not have an account yet");
    }
    setIsLoading(false);
  };

  useEffect(() => {
    checkTokenValidity();
  }, [token, navigate, alertService]);

  if (isLoading) {
    return (
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={isLoading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    );
  }

  if (isAuthenticated) {
    return <>{props.children}</>;
  } else {
    navigate(RoutingPaths.login);
    alertService.setAlert(true, "error", "You are not authenticated");
  }
};

export default SessionService;
