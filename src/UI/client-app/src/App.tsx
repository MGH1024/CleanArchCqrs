import {useEffect, useState} from 'react'
import {Routes, Route} from 'react-router-dom';
import SignIn from './views/signIn';
import SignUp from './views/signUp';
import Main from '../src/views/main';
import {Get} from './services/localStorageService';
import {GetCurrentUserByToken} from './services/accountService';
import Parties from './views/parties';
import CreateCategory from "./views/createCategory";
import {ErrorPage} from "./views/errorPage";

function App() {
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<string>("");

    useEffect(() => {
        if (!token) {
            //getToken()
        }
    });

    // const getToken = async () => {
    //     const userToken = Get('token');
    //     setToken(userToken);
    //     if (!userToken || !user) {
    //         const user = await GetCurrentUserByToken(userToken);
    //         setUser(user);
    //     } else {
    //
    //     }
    // }

    return (
        <>
            <Routes>
                <Route path="/" element={<SignIn/>}/>
                <Route path="/signup" element={<SignUp/>}/>
                <Route path="/main" element={<Main/>}/>
                <Route path="/parties" element={<Parties/>}/>
                <Route path="/createCategory" element={<CreateCategory/>}/>
                <Route path="*" element={<ErrorPage/>}/>
            </Routes>
        </>
    );
}

export default App;
