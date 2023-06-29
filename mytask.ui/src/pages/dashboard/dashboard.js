import {Box, Container, makeStyles, Tab, Tabs, Typography} from "@mui/material";
import {useEffect, useState} from "react";
import SpaceDashboardIcon from '@mui/icons-material/SpaceDashboard';
import SummarizeIcon from '@mui/icons-material/Summarize';
import AccountTreeIcon from '@mui/icons-material/AccountTree';
import { alpha } from '@mui/system';
import dashboard from '../../imgs/dashboard.png'

    const Dashboard = () => {
        const [tab, setTab] = useState(0);
        const [currentTime, setCurrentTime] = useState();

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
                        width: '50%'
                    }}
                >

                </Box>
            </Container>
        )
    }

export default Dashboard;