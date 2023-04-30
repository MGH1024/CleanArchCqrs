import {Routes, Route, Link, Navigate,Outlet} from 'react-router-dom';


interface IProtected {
    user: any,
    children?: any | null,
}

const ProtectedRouteHelper = ({user, children}: IProtected) => {
    debugger;
    if (!user || user == 'undefined') {

        return <Navigate to="/" replace/>;
    }
    return children ? children : <Outlet />;
};

export default ProtectedRouteHelper;