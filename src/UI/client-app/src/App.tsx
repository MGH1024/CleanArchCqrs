import Home from "./pages/home";
import About from "./pages/about";
import SignUp from './pages/signUp';
import SignIn from "./pages/signIn";
import Products from "./pages/products";
import Settings from "./pages/settings";
import {useEffect, useState} from 'react'
import Analytics from "./pages/analytics";
import Protected from "./utilities/protected";
import {Get} from './services/localStorageService';
import IGetUserByToken from "./types/getUserByToken";
import {Routes, Route, useNavigate} from 'react-router-dom';
import {GetCurrentUserByToken} from './services/accountService';


function App() {
    const navigate = useNavigate();
    const [user, setUser] = useState<IGetUserByToken>();
    const [token, setToken] = useState<string | null>(null);


    const [isSignedIn, setIsSignedIn] = useState<boolean>(true)

    useEffect(() => {
        (async () => {
            const userToken = Get('token');
            if (userToken === undefined || userToken === '' || userToken === null) {
                setIsSignedIn(false)
            } else {
                const userObj = await GetCurrentUserByToken(userToken);
                if (userObj) {
                    setUser(userObj.data.Data);
                    setIsSignedIn(true)
                }
            }
            navigate('/');
        })()
    }, []);

    return (
        <>
            <Routes>
                <Route path="/signIn" element={<SignIn/>}/>
                <Route path="/signUp" element={<SignUp/>}/>
                <Route path="/" element={<Home/>}/>
                <Route
                    path="/analytics"
                    element={
                        <Protected isSignedIn={isSignedIn}>
                            <Analytics/>
                        </Protected>
                    }
                />

                <Route
                    path="/settings"
                    element={
                        <Protected isSignedIn={isSignedIn}>
                            <Settings/>
                        </Protected>
                    }
                />
                <Route
                    path="/about"
                    element={
                        <Protected isSignedIn={isSignedIn}>
                            <About/>
                        </Protected>
                    }
                />
                <Route
                    path="/products"
                    element=
                        {
                            <Protected isSignedIn={isSignedIn}>
                                <Products/>
                            </Protected>
                        }
                />
                <Route path="*" element={<p>There's nothing here: 404!</p>}/>
            </Routes>
        </>
    )
}

export default App;