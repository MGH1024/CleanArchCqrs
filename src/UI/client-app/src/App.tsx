import Home from "./pages/home";
import About from "./pages/about";
import SignUp from './pages/signUp';
import SignIn from "./pages/signIn";
import Products from "./pages/products";
import Settings from "./pages/settings";
import Analytics from "./pages/analytics";
import Protected from "./utilities/protected";
import {Routes, Route} from 'react-router-dom';
import UserContext from "./contexts/userContext";

function App() {
    return (
        <>
            <UserContext>
                <Routes>
                    <Route path="/signIn" element={<SignIn/>}/>
                    <Route path="/signUp" element={<SignUp/>}/>
                    <Route path="/" element={<Home/>}/>
                    <Route
                        path="/analytics"
                        element={
                            <Protected>
                                <Analytics/>
                            </Protected>
                        }
                    />
                    <Route
                        path="/settings"
                        element={
                            <Protected>
                                <Settings/>
                            </Protected>
                        }
                    />
                    <Route
                        path="/about"
                        element={
                            <Protected>
                                <About/>
                            </Protected>
                        }
                    />
                    <Route
                        path="/products"
                        element=
                            {
                                <Protected>
                                    <Products/>
                                </Protected>
                            }
                    />
                    <Route path="*" element={<p>There's nothing here: 404!</p>}/>
                </Routes>
            </UserContext>
        </>
    )
}
export default App;