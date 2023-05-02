import React from 'react'
import { Navigate } from 'react-router-dom'

type Protect = {
    isSignedIn: any,
    children: any
}

function Protected({ isSignedIn, children }:Protect) {
    if (!isSignedIn) {
        return <Navigate to="/signin" replace />
    }
    return children
}
export default Protected