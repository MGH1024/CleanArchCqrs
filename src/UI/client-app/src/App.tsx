import Home from "./pages/home";
import About from "./pages/about";
import SignUp from './pages/signUp';
import SignIn from "./pages/signIn";
import Products from "./pages/products";
import Settings from "./pages/settings";
import {useEffect, useState} from 'react'
import Analytics from "./pages/Analytics";
import {Get} from './services/localStorageService';
import IGetUserByToken from "./types/getUserByToken";
import {Routes, Route, useNavigate} from 'react-router-dom';
import ProtectedRouteHelper from "./api/ProtectedRouteHelper";
import {GetCurrentUserByToken} from './services/accountService';


function App() {
    const navigate = useNavigate();
    const [user, setUser] = useState<IGetUserByToken>();
    const [token, setToken] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            const userToken = Get('token');
            if (!userToken) {
                await getToken();
            } else {
                const user = await GetCurrentUserByToken(userToken);
                setUser(user.data.Data);
                navigate('/home');
            }

        })()
    });

    const getToken = async () => {
        const userToken = Get('token');
        if (userToken) {
            setToken(userToken);
            const user = await GetCurrentUserByToken(userToken);
            if (user) {
                setUser(user.data.Data);
                navigate('/home');
            } else {
                navigate('/');
            }
        }
    }
    return (
        <>
            <Routes>
                <Route path="/" element={<SignIn/>}/>
                <Route path="/signUp" element={<SignUp/>}/>
                <Route path="/" element={<ProtectedRouteHelper user={user}/>}>
                    <Route path="/home" element={<Home/>}/>
                    <Route path="/settings" element={<Settings/>}/>
                    <Route path="/about" element={<About/>}/>
                    <Route path="/analytics" element={<Analytics/>}/>
                </Route>
                <Route path="/products" element={<Products/>}/>
                <Route path="*" element={<p>There's nothing here: 404!</p>}/>
            </Routes>
        </>
    )
}

export default App;