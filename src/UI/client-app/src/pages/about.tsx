﻿import React from "react";
import Box from '@mui/material/Box';
import Navbar from "../components/navbar";
import Sidenav from "../components/sidenav";

export default function About() {
    return (
        <>
           <Navbar/>
            <Box height={30}/>
            <Box sx={{display: "flex"}}>
                <Sidenav/>
                <Box component="main" sx={{flexGrow: 1, p: 3}}>
                    <h1>About</h1>
                </Box>
            </Box>
        </>
    )
}