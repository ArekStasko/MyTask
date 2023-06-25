import {Box, Link, Typography} from "@mui/material";


const AuthNavbar = (props) => {
    return (
        <>
        <Box sx={{width: '100%', display:"flex", justifyContent: "space-around", alignItems: "center",  position: 'absolute', top: 20, zIndex: 'tooltip'}}>
            <Typography color="primary" variant="h4" mb="0" gutterBottom>
                MyTask
            </Typography>
            <Link href={props.link} align="center" underline="none" sx={{mt: 0.5}} >
                {props.sectionName}
            </Link>
        </Box>
            {props.children}
        </>
    )
}

export default AuthNavbar;