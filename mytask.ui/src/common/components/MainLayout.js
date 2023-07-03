import React, { useEffect, useState } from "react";
import SessionService from "../services/sessionService";
import Sidebar from "./Sidebar";
import dashboard from "../../imgs/dashboard.png";
import { Container } from "@mui/material";
import { alpha } from "@mui/system";

const MainLayout = (props) => {
  const [stage, setStage] = useState("dashboard");

  return (
    <Container
      sx={{
        height: "100%",
        bgcolor: "black",
        display: "flex",
        justifyContent: "space-between",
        backgroundImage: stage === "dashboard" ? `url(${dashboard})` : null,
        backgroundSize: "cover",
        backgroundPosition: "center",
        alignItems: "flex-end",
        m: "0",
        p: "0",
        "@media (min-width: 1200px)": {
          maxWidth: "100%",
        },
        "@media (min-width: 600px)": {
          m: "0",
          p: "0",
        },
        backdropFilter: "blur(10px)",
      }}
    >
      <SessionService>
        <Sidebar />
        {props.children}
      </SessionService>
    </Container>
  );
};

export default MainLayout;
