import { Route, Routes } from "react-router-dom";
import RoutingConstants from "./RoutingConstants";
import Homepage from "../pages/homepage/homepage";
import Login from "../pages/login/login";
import Register from "../pages/register/register";
import AuthNavbar from "../common/components/AuthNavbar";
import Dashboard from "../pages/dashboard/dashboard";
import Reports from "../pages/reports/reports";
import Projects from "../pages/projects/projects";
import MainLayout from "../common/components/MainLayout";
import SessionService from "../common/services/sessionService";
import AddProject from "../pages/addProject/addProject";
import GenerateRaport from "../pages/generateRaport/generateRaport";
import AddTask from "../pages/addTask/addTask";

const MainRouting = () => (
  <Routes>
    <Route path={RoutingConstants.root} element={<Homepage />} />
    <Route
      path={RoutingConstants.login}
      element={
        <AuthNavbar link={"/register"} sectionName={"Register"}>
          <Login />
        </AuthNavbar>
      }
    />
    <Route
      path={RoutingConstants.register}
      element={
        <AuthNavbar link={"/login"} sectionName={"Login"}>
          <Register />
        </AuthNavbar>
      }
    />
    <Route
      path={RoutingConstants.dashboard}
      element={
        <SessionService>
          <MainLayout>
            <Dashboard />
          </MainLayout>
        </SessionService>
      }
    />
    <Route
      path={`${RoutingConstants.raports}/:id`}
      element={
        <MainLayout>
          <Reports />
        </MainLayout>
      }
    />
    <Route
      path={`${RoutingConstants.projects}/:id`}
      element={
        <MainLayout>
          <Projects />
        </MainLayout>
      }
    />
    <Route
      path={RoutingConstants.addProject}
      element={
        <SessionService>
          <AddProject />
        </SessionService>
      }
    />
    <Route
      path={RoutingConstants.addTask}
      element={
        <SessionService>
          <AddTask />
        </SessionService>
      }
    />
    <Route
      path={RoutingConstants.generateRaport}
      element={
        <SessionService>
          <GenerateRaport />
        </SessionService>
      }
    />
  </Routes>
);

export default MainRouting;
