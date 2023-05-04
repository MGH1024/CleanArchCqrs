import * as React from 'react';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Link from '@mui/material/Link';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import {useContext, useState} from "react";
import Toast from "../../components/toast";
import {useNavigate} from "react-router-dom";
import Checkbox from '@mui/material/Checkbox';
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import {Login} from "../../services/accountService";
import CssBaseline from '@mui/material/CssBaseline';
import {AppContext} from "../../contexts/appContext";
import IAuthResponse from "../../types/auth/authRespose";
import FormControlLabel from '@mui/material/FormControlLabel';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import {createTheme, ThemeProvider} from '@mui/material/styles';


function Copyright(props: any) {

    return (
        <Typography variant="body2" color="text.secondary" align="center" {...props}>
            {'Copyright © '}
            <Link color="inherit" href="https://github.com/MGH1024">
                MGH1024
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const theme = createTheme();

export default function SignIn() {

    let navigate = useNavigate();
    const {setUser} = useContext(AppContext)
    const {showToast, setShowToast} = useContext(AppContext);

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [rememberMe, setRememberMe] = useState(true);
    const [usernameError, setUsernameError] = useState<boolean>(false);
    const [passwordError, setPasswordError] = useState<boolean>(false);


    const handleUsernameChange = async (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value
        setUsername(value);
        if (value)
            setUsernameError(false);
    }

    const handleRememberMeChange = (event: React.ChangeEvent<HTMLInputElement>) => {

        setRememberMe(event.target.checked);
    };
    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value
        setPassword(value);
        if (value)
            setPasswordError(false);
    }
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (!username || !password) {
            if (!username)
                setUsernameError(true);
            if (!password)
                setPasswordError(true);
            return;
        }

        const result: IAuthResponse = await Login({
            username,
            password,
            rememberMe,
        });

        if (result.Success) {
            setUser({
                username: username,
            });
            setShowToast({message: 'login success.', show: true, severity: 'success'})
            navigate("/");
        } else {
            setShowToast({message: 'login failed.', show: true, severity: 'error'})
        }
    };

    return (
        <ThemeProvider theme={theme}>
            <Container component="main" maxWidth="xs">
                <CssBaseline/>
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{m: 1, bgcolor: 'secondary.main'}}>
                        <LockOutlinedIcon/>
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign in
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit} noValidate sx={{mt: 1}}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="username"
                            label="Username"
                            name="username"
                            autoComplete="username"
                            autoFocus
                            value={username}
                            error={usernameError}
                            onChange={handleUsernameChange}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                            value={password}
                            error={passwordError}
                            onChange={handlePasswordChange}
                        />

                        <FormControlLabel
                            control={<Checkbox
                                value={rememberMe}
                                onChange={handleRememberMeChange}
                                color="primary"
                            />}
                            label="Remember me"
                            name="rememberMe"
                            id="rememberMe"
                            checked={rememberMe}
                        />


                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{mt: 3, mb: 2}}
                        >
                            Sign In
                        </Button>
                        <Grid container>
                            <Grid item xs>
                                <Link href="#" variant="body2">
                                    Forgot password?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link href="/signup" variant="body2">
                                    {"Don't have an account? Sign Up"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>

                <Copyright sx={{mt: 8, mb: 4}}/>
            </Container>
            <Toast/>
        </ThemeProvider>
    );
}