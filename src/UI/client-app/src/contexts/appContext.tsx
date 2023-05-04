import { AlertColor } from '@mui/material';
import {createContext, Dispatch, ReactNode, SetStateAction, useState} from 'react';

export type User = {
    username: string
}

type Toast = {message: string, show: boolean, severity: AlertColor | undefined}

export interface UserContextInterface {
    user: User
    setUser: Dispatch<SetStateAction<User>>
    showToast: Toast
    setShowToast: Function
}

const defaultState = {
    user: {
        username: '',
    },
    setUser: (user: User) => {
    },
    showToast: {message: '', severity: 'success', show: false},
} as UserContextInterface
export const AppContext = createContext(defaultState)


type UserProviderProps = {
    children: ReactNode
}
export default function UserProvider({children}: UserProviderProps) {
    const [user, setUser] = useState<User>({
        username: '', 
    });
    const [showToast, setShowToast] = useState<Toast>({message: '', severity: 'success', show: false});
    return (
        <AppContext.Provider value={{user, setUser, showToast, setShowToast}}>
            {children}
        </AppContext.Provider>
    )
}
