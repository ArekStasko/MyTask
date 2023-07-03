import {Navigate, Route, Routes} from "react-router-dom";
import RoutingConstants from "./RoutingConstants";
import Homepage from "../pages/homepage/homepage";
import Login from "../pages/login/login";
import Register from "../pages/register/register";
import AuthNavbar from "../common/components/AuthNavbar";
import Dashboard from "../pages/dashboard/dashboard";
import Reports from "../pages/reports/reports";
import Projects from "../pages/projects/projects";
import MainLayout from "../common/components/MainLayout";

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
                element={<MainLayout><Dashboard/></MainLayout>}
            />
        <Route
            path={RoutingConstants.reports}
            element={<MainLayout><Reports/></MainLayout>}
        />
        <Route
            path={RoutingConstants.projects}
            element={<MainLayout><Projects/></MainLayout>}
        />
    </Routes>
)

export default MainRouting