import Home from "./pages/home";
import About from "./pages/about";
import SignUp from './pages/auth/signUp';
import SignIn from "./pages/auth/signIn";
import Analytics from "./pages/analytics";
import Protected from "./utilities/protected";
import {Routes, Route} from 'react-router-dom';
import Products from "./pages/products/products";
import AppContext from "./contexts/appContext";
import AddProduct from "./pages/products/addProduct";
import EditProduct from "./pages/products/EditProduct";

function App() {
    return (
        <>
            <AppContext>
                <Routes>


                    <Route path="/products" element={
                        <Protected>
                            <Products/>
                        </Protected>
                    }/>
                    <Route path="/products/addProduct" element={
                        <Protected>
                            <AddProduct/>
                        </Protected>
                    }/>
                    <Route path="/products/:id" element={
                        <Protected>
                            <EditProduct/>
                        </Protected>
                    }/>

                    <Route
                        path="/analytics"
                        element={
                            <Protected>
                                <Analytics/>
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
                    <Route path="/signIn" element={<SignIn/>}/>
                    <Route path="/signUp" element={<SignUp/>}/>
                    <Route path="/" element={<Home/>}/>
                    <Route path="*" element={<p>There's nothing here: 404!</p>}/>
                </Routes>
            </AppContext>
        </>
    )
}

export default App;