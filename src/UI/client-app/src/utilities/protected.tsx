import {useContext} from 'react'
import {Navigate} from 'react-router-dom'
import {AppContext} from "../contexts/appContext";

type Protect = {
    children: any
}

function Protected({children}: Protect) {
    debugger;
    const user = useContext(AppContext);
    if (user.user.username === '' || user.user.username === null) {
        return <Navigate to="/signin" replace/>
    }
    return children
}

export default Protected