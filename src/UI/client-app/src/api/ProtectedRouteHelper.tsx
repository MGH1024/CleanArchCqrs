import {Navigate} from 'react-router-dom';

interface IProtected {
    user: any,
}

const ProtectedRouteHelper = ({user}: IProtected) => {
    if (!user) {
        return <Navigate to="/" replace/>;
    }
    return <Navigate to="/" />;
   
};

export default ProtectedRouteHelper;