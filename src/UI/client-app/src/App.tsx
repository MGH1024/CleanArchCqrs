import {useEffect, useState} from 'react'
import {Routes, Route, BrowserRouter} from 'react-router-dom';

import Main from '../src/views/main';
import {Get} from './services/localStorageService';
import {GetCurrentUserByToken} from './services/accountService';
import Parties from './views/parties';
import CreateCategory from "./views/createCategory";
import {ErrorPage} from "./views/errorPage";
import Sidenav from "./components/sidenav";
import Home from "./pages/home";
import Settings from "./pages/settings";
import About from "./pages/about";
import Analytics from "./pages/Analytics";
import Products from "./pages/products";
import SignIn from "./pages/signIn";
import SignUp from './pages/signUp';

// function App() {
//     const [token, setToken] = useState<string | null>(null);
//     const [user, setUser] = useState<string>("");
//
//     useEffect(() => {
//         if (!token) {
//             //getToken()
//         }
//     });
//
//     // const getToken = async () => {
//     //     const userToken = Get('token');
//     //     setToken(userToken);
//     //     if (!userToken || !user) {
//     //         const user = await GetCurrentUserByToken(userToken);
//     //         setUser(user);
//     //     } else {
//     //
//     //     }
//     // }
//
//     return (
//         <>
//             <Routes>
//                 <Route path="/" element={<SignIn/>}/>
//                 <Route path="/signup" element={<SignUp/>}/>
//                 <Route path="/main" element={<Main/>}/>
//                 <Route path="/parties" element={<Parties/>}/>
//                 <Route path="/createCategory" element={<CreateCategory/>}/>
//                 <Route path="*" element={<ErrorPage/>}/>
//             </Routes>
//         </>
//     );
// }
//
// export default App;

function App() {
    return (
        <>

            <Routes>
                <Route path="/" element={<SignIn/>}/>
                <Route path="/signUp" element={<SignUp/>}/>
                <Route path="/home" element={<Home/>}/>
                <Route path="/settings" element={<Settings/>}/>
                <Route path="/about" element={<About/>}/>
                <Route path="/analytics" element={<Analytics/>}/>
                <Route path="/products" element={<Products/>}/>
            </Routes>
           
        </>
    )
}

export default App;