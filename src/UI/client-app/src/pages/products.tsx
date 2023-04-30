import React from "react";
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Sidenav from "../components/sidenav";
import Navbar from "../components/Navbar";
import ProductList from "./products/ProductList";
import ProductList2 from "./products/ProductList2";

export default function Products() {
    return (
        <>
            <div className="bgColor">
                <Navbar/>
                <Box height={70}/>
                <Box sx={{display: "flex"}}>
                    <Sidenav/>
                    <Box component="main" sx={{flexGrow: 1, p: 3}}>
                        <ProductList2 />
                    </Box>
                </Box>
            </div>
        </>
    )
}