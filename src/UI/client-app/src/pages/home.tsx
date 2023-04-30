import React from "react";
import Sidenav from "../components/sidenav";
import AccordionDash from "../components/accordionDash";
import Box from '@mui/material/Box';
import Navbar from "../components/navbar";
import Grid from '@mui/material/Grid';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import Stack from '@mui/material/Stack';
import '../assets/css/Dash.css' ;
import StorefrontIcon from '@mui/icons-material/Storefront';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import ShoppingBagIcon from '@mui/icons-material/ShoppingBag';
import BarChart from "../charts/BarChart";
import CountUp from 'react-countup';

export default function Home() {
    return (
        <>
            <div className="bgColor">
                <Navbar/>
                <Box height={70}/>
                <Box sx={{display: "flex"}}>
                    <Sidenav/>
                    <Box component="main" sx={{flexGrow: 1, p: 3}}>
                        <Grid container spacing={2}>
                            <Grid item xs={8}>
                                <Stack spacing={2} direction="row">
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient">
                                        <CardContent>
                                            <div className="icon-style">
                                                <CreditCardIcon/>
                                            </div>
                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                $<CountUp delay={0.9} end={500.00} duration={0.3} />
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                Total Earnings
                                            </Typography>

                                        </CardContent>

                                    </Card>
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient-light">
                                        <CardContent>
                                            <div className="icon-style">
                                                <ShoppingBagIcon/>
                                            </div>
                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                $<CountUp delay={0.9} end={900.00} duration={0.1} />
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                Total Order
                                            </Typography>
                                        </CardContent>
                                    </Card>
                                </Stack>
                            </Grid>
                            <Grid item xs={4}>
                                <Stack spacing={2}>
                                    <Card sx={{minWidth: 345}} className="gradient-light">
                                        <Stack spacing={2} direction="row">
                                            <div className="icon-style">
                                                <StorefrontIcon/>
                                            </div>
                                            <div className="padding-all">
                                                <span className="price-title">$203k</span>
                                                <br/>
                                                <span className="price-sub-title">Total Income</span>
                                            </div>
                                        </Stack>
                                    </Card>
                                    <Card sx={{minWidth: 345}}>
                                        <Stack spacing={2} direction="row">
                                            <div className="icon-style-black">
                                                <StorefrontIcon/>
                                            </div>
                                            <div className="padding-all">
                                                <span className="price-title">$203k</span>
                                                <br/>
                                                <span className="price-sub-title">Total Income</span>
                                            </div>
                                        </Stack>
                                    </Card>
                                </Stack>
                            </Grid>
                        </Grid>
                        <Box height={20}/>
                        <Grid container spacing={2}>
                            <Grid item xs={8}>
                                <Card sx={{height: 60 + "vh"}}>
                                    <CardContent>
                                        <BarChart/>
                                    </CardContent>

                                </Card>
                            </Grid>
                            <Grid item xs={4}>
                                <Card sx={{height: 60 + "vh"}}>
                                    <CardContent>
                                        <div className="padding-all">
                                            <span className="price-title">  Popular Products</span>
                                        </div>
                                        <AccordionDash/>
                                    </CardContent>

                                </Card>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
            </div>
        </>
    )
}