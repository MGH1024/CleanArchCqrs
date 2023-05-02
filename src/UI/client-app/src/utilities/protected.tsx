import {useContext} from 'react'
import {Navigate} from 'react-router-dom'
import {UserContext} from "../contexts/userContext";

type Protect = {
    children: any
}

function Protected({children}: Protect) {
    const user = useContext(UserContext);
    if (user.user.username === '' || user.user.username === null) {
        return <Navigate to="/signin" replace/>
    }
    return children
}

export default Protected