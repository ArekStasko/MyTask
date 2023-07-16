import {
  Backdrop,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CircularProgress,
  Container,
  Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { alpha } from "@mui/system";
import { useGetTasksQuery } from "../../common/slices/getTasks/getTasks";
import { stateColors } from "../../common/services/taskStateService";
import { states } from "../../common/services/taskStateService";
import ActionsDialog from "../../common/components/ActionsDialog";

const Dashboard = () => {
  const [currentTime, setCurrentTime] = useState();
  const { data, isLoading } = useGetTasksQuery();

  useEffect(() => {
    const currentDate = new Date();
    const currentHour = currentDate.getHours();
    const currentMinute = currentDate.getMinutes();
    setCurrentTime(`${currentHour}:${currentMinute}`);
  }, []);

  useEffect(() => {
    setInterval(() => {
      const currentDate = new Date();

      const currentHour = currentDate.getHours();
      const currentMinute = currentDate.getMinutes();
      setCurrentTime(`${currentHour}:${currentMinute}`);
    }, 60000);
  }, []);

  const getCurrentDate = () => {
    const currentDate = new Date();
    const month = currentDate.getMonth() + 1;
    const day = currentDate.getDate();
    return `${day}/${month}`;
  };

  const getCurrentDay = () =>
    new Date().toLocaleString("en-us", { weekday: "long" });

  return (
    <Container
      sx={{
        height: "100%",
        display: "flex",
        justifyContent: "space-between",
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
      {isLoading ? (
        <Backdrop
          sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
          open={isLoading}
        >
          <CircularProgress color="inherit" />
        </Backdrop>
      ) : (
        <>
          <ActionsDialog />
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "flex-start",
            }}
          >
            <Typography color="white" variant="h1" gutterBottom sx={{ mt: 2 }}>
              {currentTime}
            </Typography>
            <Typography color="white" variant="h3" gutterBottom sx={{ mt: 2 }}>
              {getCurrentDate()}
            </Typography>
            <Typography color="white" variant="h2" gutterBottom sx={{ mt: 2 }}>
              {getCurrentDay()}
            </Typography>
          </Box>
          <Box
            sx={{
              width: "25%",
              height: "100%",
              display: "flex",
              flexDirection: "column",
              justifyContent: "flex-start",
              alignItems: "center",
            }}
          >
            <Typography color="white" variant="h4" gutterBottom sx={{ mt: 2 }}>
              Upcoming Tasks
            </Typography>
            {data.slice(0, 3).map((task) => (
              <Card
                key={task.id}
                sx={{
                  minWidth: 275,
                  mt: 2,
                  mb: 2,
                  bgcolor: (theme) => alpha("#e3d6d5", 0.6),
                  backdropFilter: "blur(10px)",
                }}
              >
                <Box
                  sx={{
                    width: "100%",
                    p: 0.5,
                    pl: 1,
                    bgcolor: (theme) =>
                      alpha(`${stateColors[task.state]}`, 0.6),
                    backdropFilter: "blur(10px)",
                  }}
                >
                  <Typography color="text.secondary">
                    {states[task.state]}
                  </Typography>
                </Box>
                <CardContent>
                  <Typography variant="h5" component="div">
                    {task.name}
                  </Typography>
                  <Typography variant="body2">{task.description}</Typography>
                </CardContent>
                <CardActions>
                  <Button size="small">See details</Button>
                </CardActions>
              </Card>
            ))}
          </Box>
        </>
      )}
    </Container>
  );
};

export default Dashboard;
