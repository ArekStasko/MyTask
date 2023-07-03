import jwtDecode from "jwt-decode";
import { GetToken } from "./cookieService";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";
import { useEffect } from "react";

const SessionService = (props) => {
  const token = GetToken();
  const navigate = useNavigate();

  useEffect(() => {
    if (token) {
      const decodedToken = jwtDecode(token);
      const currentTime = Date.now() / 1000; // obecny czas w sekundach
      const tokenExpiration = decodedToken.exp;

      if (tokenExpiration < currentTime) {
        navigate(RoutingPaths.login);
      }
    } else {
      navigate(RoutingPaths.register);
    }
  }, []);

  return <>{props.children}</>;
};

export default SessionService;
