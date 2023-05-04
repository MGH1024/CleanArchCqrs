import React from "react";
import Box from '@mui/material/Box';
import Sidenav from "../../components/sidenav";
import Navbar from "../../components/navbar";
import ProductList from "./ProductList";
import Toast from "../../components/toast";

export default function Products() {
    return (
        <>
            <div className="bgColor">
                <Navbar/>
                <Box height={70}/>
                <Box sx={{display: "flex"}}>
                    <Sidenav/>
                    <Box component="main" sx={{flexGrow: 1, p: 3}}>
                        <Toast/>
                        <ProductList />
                    </Box>
                </Box>
            </div>
        </>
    )
}