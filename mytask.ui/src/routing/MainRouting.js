import {Navigate, Route, Routes} from "react-router-dom";
import RoutingConstants from "./RoutingConstants";
import Homepage from "../pages/homepage/homepage";
import Login from "../pages/login/login";
import Register from "../pages/register/register";
import AuthNavbar from "../common/components/AuthNavbar";

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
    </Routes>
)

export default MainRouting