import {
    Box, Button,
    Card,
    CardActions,
    CardContent,
    CircularProgress,
    Container,
    makeStyles,
    Tab,
    Tabs,
    Typography
} from "@mui/material";
import React, {useEffect, useState} from "react";
import SpaceDashboardIcon from '@mui/icons-material/SpaceDashboard';
import SummarizeIcon from '@mui/icons-material/Summarize';
import AccountTreeIcon from '@mui/icons-material/AccountTree';
import { alpha } from '@mui/system';
import dashboard from '../../imgs/dashboard.png'
import {useGetTasksQuery} from "../../common/slices/getTasks/getTasks";
import {stateColors} from "../../common/services/taskStateService";
import {states} from "../../common/services/taskStateService";
import {useGetProjectsQuery} from "../../common/slices/getProjects/getProjects";

    const Dashboard = () => {
        const [tab, setTab] = useState(0);
        const [currentTime, setCurrentTime] = useState();
        const {data, isLoading} = useGetTasksQuery();
        const {data: projectData, isLoading: projectsLoading} = useGetProjectsQuery();

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
            const month = currentDate.getMonth() +1;
            const day = currentDate.getDate();
            return `${day}/${month}`;
        }

        const getCurrentDay = () => new Date().toLocaleString('en-us', {weekday:'long'});


        return (
            <Container
                sx={{
                    height: "100%",
                    bgcolor: "black",
                    backgroundImage: `url(${dashboard})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    display: "flex",
                    justifyContent: "space-between",
                    alignItems: "flex-end",
                    m: "0",
                    p: "0",
                    '@media (min-width: 1200px)': {
                        maxWidth: '100%'
                    },
                    '@media (min-width: 600px)': {
                        m: "0",
                        p: "0",
                    }
                }}
            >
                <Box sx={{
                    height: "100%",
                    width: "25%",
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "space-evenly",
                    alignItems: "center",
                    bgcolor: (theme) => alpha('#e3d6d5', 0.7),
                    p: 4,
                }}>
                    <Typography color="primary" variant="h4" gutterBottom sx={{ mt: 5 }}>
                        MyTask
                    </Typography>
                    <Tabs
                        orientation="vertical"
                        variant="scrollable"
                        value={tab}
                        onChange={(event, newTab) => setTab(newTab)}
                        sx={{
                            borderRight: 0,
                            borderColor: 'divider',
                            width: '100%'
                    }}
                    >
                        <Tab
                            icon={<SpaceDashboardIcon/>}
                            iconPosition="start"
                            sx={{color: "#212121", fontSize: "large", borderRadius: '10%', m:2, mr:0, bgcolor: (theme) => alpha('#e3d6d5', 0.7) }}
                            iconPosition="start"
                            label="Dashboard"
                        />
                        <Tab
                            icon={<SummarizeIcon/>}
                            iconPosition="start"
                            sx={{color: "#212121", fontSize: "large", borderRadius: '10%', m:2, mr:0, bgcolor: (theme) => alpha('#e3d6d5', 0.7) }}
                            iconPosition="start"
                            label="Reports"
                        />
                        <Tab
                            icon={<AccountTreeIcon/>}
                            iconPosition="start"
                            sx={{color: "#212121", fontSize: "large", borderRadius: '10%', m:2, mr:0, bgcolor: (theme) => alpha('#e3d6d5', 0.7) }}
                            iconPosition="start"
                            label="Projects"
                        />
                    </Tabs>
                </Box>
                <Box>
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
                        width: '25%',
                        height: '100%',
                        display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'flex-start',
                        alignItems: 'center'
                    }}
                >
                    <Typography color="white" variant="h4" gutterBottom sx={{ mt: 2 }}>
                        Upcoming Tasks
                    </Typography>
                        {
                            isLoading ? (
                                <CircularProgress />
                            ) : (
                                data.slice(0,3).map(task =>
                                    <Card key={task.id} sx={{ minWidth: 275, mt: 2, mb: 2, bgcolor: (theme) => alpha('#e3d6d5', 0.7) }}>
                                        <Box sx={{ width: '100%', p: 0.5, pl: 1, bgcolor: (theme) => alpha(`${stateColors[task.state]}`, 0.7) }}>
                                            <Typography color="text.secondary">
                                                {states[task.state]}
                                            </Typography>
                                        </Box>
                                        <CardContent>
                                            <Typography variant="h5" component="div">
                                                {task.name}
                                            </Typography>
                                            <Typography variant="body2">
                                                {task.description}
                                            </Typography>
                                        </CardContent>
                                        <CardActions>
                                            <Button size="small">See details</Button>
                                        </CardActions>
                                    </Card>
                                )
                            )
                        }
                </Box>
                <Box
                    sx={{
                        width: '25%',
                        height: '100%',
                        display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'flex-start',
                        alignItems: 'center'
                    }}
                >
                    <Typography color="white" variant="h4" gutterBottom sx={{ mt: 2 }}>
                        Active Projects
                    </Typography>
                    {
                        projectsLoading ? (
                            <CircularProgress />
                        ) : (
                            projectData.slice(0,6).map(project =>
                                <Card key={project.id} sx={{ minWidth: 275, mt: 2, mb: 2, bgcolor: (theme) => alpha('#e3d6d5', 0.7) }}>
                                    <CardContent>
                                        <Typography variant="h5" component="div">
                                            {project.name}
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button size="small">See more</Button>
                                    </CardActions>
                                </Card>
                            )
                        )
                    }
                </Box>
            </Container>
        )
    }

export default Dashboard;