import {Box, Container, Tab, Tabs, Typography} from "@mui/material";
import {useState} from "react";
import SpaceDashboardIcon from '@mui/icons-material/SpaceDashboard';
import SummarizeIcon from '@mui/icons-material/Summarize';
import AccountTreeIcon from '@mui/icons-material/AccountTree';
import { alpha } from '@mui/system';
import dashboard from '../../imgs/dashboard.jpg'

    const Dashboard = () => {
        const [tab, setTab] = useState(0);

        return (
            <Container
                sx={{
                    height: "100%",
                    backgroundImage: `url(${dashboard})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    display: "flex",
                    m: "0",
                    p: "0",
                }}
            >
                <Box sx={{
                    height: "100%",
                    display: "flex",
                    flexDirection: "column",
                    bgcolor: (theme) => alpha('#e3d6d5', 0.5),
                }}>
                    <Typography variant="h5" gutterBottom sx={{ mt: 5 }}>
                        MyTask
                    </Typography>
                    <Tabs
                        orientation="vertical"
                        variant="scrollable"
                        value={tab}
                        onChange={(event, newTab) => setTab(newTab)}
                        sx={{ borderRight: 1, borderColor: 'divider' }}
                    >
                        <Tab icon={<SpaceDashboardIcon/>} iconPosition="start" sx={{color: "#212121", fontSize: "large", height: 80}} iconPosition="start" label="Dashboard" />
                        <Tab icon={<SummarizeIcon/>} iconPosition="start" sx={{color: "#212121", fontSize: "large", height: 80}} iconPosition="start" label="Reports" />
                        <Tab icon={<AccountTreeIcon/>} iconPosition="start" sx={{color: "#212121", fontSize: "large", height: 80}} iconPosition="start" label="Projects" />
                    </Tabs>
                </Box>
            </Container>
        )
    }

export default Dashboard;