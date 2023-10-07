import React from "react";
import Box from '@mui/material/Box';
import Navbar from "../components/navbar";
import Sidenav from "../components/sidenav";
import Typography from '@mui/material/Typography';
import Image from "../components/image";
import Link from '@mui/material/Link';

export default function About() {

    return (
        <>
            <Navbar/>
            <Box height={70}/>

            <Box sx={{display: "flex"}}>
                <Sidenav/>
                <Box component="main" sx={{flexGrow: 1, p: 3}}>
                    <Box
                        sx={{
                            marginTop: 0,
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center',
                        }}
                    >
                        <Image/>
                        <Typography variant="h3" gutterBottom>
                            Meysam Ghiasvand
                        </Typography>

                        <Typography variant="h6" gutterBottom>
                            <Link href="https://www.linkedin.com/in/meysam-ghiasvand/" underline="none">
                                LinkedIn
                            </Link>
                        </Typography>
                    </Box>


                    <Typography variant="h5" gutterBottom color='primary' sx={{fontWeight: 'bold'}}>
                        SUMMARY
                    </Typography>
                    <Typography variant="h6" gutterBottom>
                        .Net developer with more than 9 years of experience .Expert in C# and .Net technologies
                        .Skilled in architecting and building large-scale applications .Built and maintained +50
                        projects in various industries .Proficient in optimizing enterprise systems performance
                        ,and good knowledge in JavaScript and some related libraries.
                    </Typography>

                    <Box height={20}/>
                    <Typography variant="h5" gutterBottom color='primary' sx={{fontWeight: 'bold'}}>
                        SKILLS
                    </Typography>

                    <Typography variant="h6" gutterBottom>
                        <Typography variant="h5" gutterBottom sx={{fontWeight: 'bold'}}> Expert in :</Typography>
                        C#, .NET , .NET Core , SQL Server ,TSQL , OOP , Multi-Threading , Concurrency
                        ,Microservices, TDD , WPF, WCF ,RestFul API , Onion/Clean architecture , CQRS , MVC , Design
                        patterns and principles (SOLID, DRY, KISS, …), Unit test , Integration test , Dapper ,
                        EntityFramework , GIT /TFS, Windows servers.
                        <Box height={30}/>
                        <Typography variant="h5" sx={{fontWeight: 'bold'}} gutterBottom> Good experience with
                            :</Typography>
                        gRPC , Docker , RabbitMQ , Redis , MySQL ,Java Script , Jquery
                        ,Angularjs,react js.
                        <Box height={30}/>
                        <Typography variant="h5" sx={{fontWeight: 'bold'}} gutterBottom> Familiar/Interested
                            :</Typography>
                        Cloud services, NoSQL databases, MongoDB, CI/CD, Elasticsearch, GraphQL,
                        Kubernetes.
                        <Box height={10}/>
                    </Typography>
                </Box>
            </Box>
        </>
    )
}