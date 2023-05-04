import IUser from '../types/context/user';
import IToast from "../types/context/toast";
import {createContext, ReactNode, useState} from 'react';
import IUserContextInterface from "../types/context/userContextInterface";


const defaultState = {
    user: {
        username: '',
    },
    setUser: (user: IUser) => {
    },
    showToast: {message: '', severity: 'success', show: false},
} as IUserContextInterface
export const AppContext = createContext(defaultState)


type UserProviderProps = {
    children: ReactNode
}
export default function UserProvider({children}: UserProviderProps) {
    const [user, setUser] = useState<IUser>({
        username: '',
    });
    const [showToast, setShowToast] = useState<IToast>({message: '', severity: 'success', show: false});
    return (
        <AppContext.Provider value={{user, setUser, showToast, setShowToast}}>
            {children}
        </AppContext.Provider>
    )
}
