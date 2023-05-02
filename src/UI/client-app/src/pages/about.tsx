import React from "react";
import Box from '@mui/material/Box';
import Navbar from "../components/navbar";
import Button from '@mui/material/Button';
import Sidenav from "../components/sidenav";
import IGetCategoryById from "../types/getCategoryById";
import {GetCategoryById} from "../services/categoryServices";

export default function About() {
    // const handleClick = async () => {
    //     let value: IGetCategoryById = {
    //         id: 1,
    //     };
    //     await GetCategoryById(value);
    // }
    return (
        <>
            <Navbar/>
            <Box height={30}/>
            <Box sx={{display: "flex"}}>
                <Sidenav/>
                <Box component="main" sx={{flexGrow: 1, p: 3}}>
                    <h1>About</h1>
                    {/*<Button*/}
                    {/*    onClick={handleClick}*/}
                    {/*>*/}
                    {/*    Click me*/}
                    {/*</Button>*/}
                </Box>
            </Box>
        </>
    )
}