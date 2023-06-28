import {Navigate, Route, Routes} from "react-router-dom";
import RoutingConstants from "./RoutingConstants";
import Homepage from "../pages/homepage/homepage";
import Login from "../pages/login/login";
import Register from "../pages/register/register";
import AuthNavbar from "../common/components/AuthNavbar";
import Dashboard from "../pages/dashboard/dashboard";
import SessionService from "../common/services/sessionService";

const MainRouting = () => (
    <Routes>
        <Route
            path={RoutingConstants.root}
            element={<Homepage/>}
        />
        <Route
            path={RoutingConstants.login}
            element={<AuthNavbar link={"/register"} sectionName={"Register"} ><Login/></AuthNavbar>}
        />
        <Route
            path={RoutingConstants.register}
            element={<AuthNavbar link={"/login"} sectionName={"Login"} ><Register/></AuthNavbar>}
        />
            <Route
                path={RoutingConstants.dashboard}
                element={<SessionService><Dashboard/></SessionService>}
            />
    </Routes>
)

export default MainRouting