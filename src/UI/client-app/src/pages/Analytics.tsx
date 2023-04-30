import React from "react";
import Sidenav from "../components/sidenav";
import AccordionDash from "../components/AccordionDash";
import Box from '@mui/material/Box';
import Navbar from "../components/Navbar";
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
import {GeoChart} from "../charts/GeoChart";
import PieChart from "../charts/PieChart";
import {HBarChart} from "../charts/HBarChart";
import CountUp from 'react-countup';

export default function Analytics() {
    return (
        <>
            <div className="bgColor">
                <Navbar/>
                <Box height={70}/>
                <Box sx={{display: "flex"}}>
                    <Sidenav/>
                    <Box component="main" sx={{flexGrow: 1, p: 3}}>
                        <Grid container spacing={2}>

                            <Grid item xs={5}>
                                <Stack spacing={2} direction="row">
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient">
                                        <CardContent>

                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                Visitors
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                <CountUp delay={0.9} end={25180} duration={0.3} />
                                            </Typography>

                                        </CardContent>

                                    </Card>
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient-light">
                                        <CardContent>

                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                Visitors
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                <CountUp delay={0.7} end={16800} duration={0.2} />
                                            </Typography>
                                        </CardContent>

                                    </Card>

                                </Stack>
                                <Box height={14}/>
                                <Stack spacing={2} direction="row">
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient">
                                        <CardContent>

                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                Visitors
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                <CountUp delay={0.8} end={18700} duration={0.5} />
                                            </Typography>

                                        </CardContent>

                                    </Card>
                                    <Card sx={{minWidth: 49 + "%", height: 150}} className="gradient-light">
                                        <CardContent>

                                            <Typography gutterBottom variant="h5" component="div"
                                                        sx={{color: "#ffffff"}}>
                                                Visitors
                                            </Typography>
                                            <Typography gutterBottom variant="body2" component="div"
                                                        sx={{color: "#ccd1d1"}}>
                                                <CountUp delay={0.77} end={18700} duration={0.2} />
                                            </Typography>
                                        </CardContent>
                                    </Card>
                                </Stack>
                            </Grid>


                            <Grid item xs={7}>
                                <Stack spacing={2}>
                                    <Card sx={{minWidth: 345, height: 314}} className="gradient-light">
                                       <HBarChart/>
                                    </Card>
                                </Stack>
                            </Grid>
                        </Grid>
                        <Box height={20}/>
                        <Grid container spacing={2}>
                            <Grid item xs={8}>
                                <Card sx={{height: 46 + "vh"}}>
                                    <CardContent>
                                        <GeoChart/>
                                    </CardContent>

                                </Card>
                            </Grid>
                            <Grid item xs={4}>
                                <Card sx={{height: 46 + "vh"}}>
                                    <CardContent>
                                        <PieChart/>
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