import {createContext, Dispatch, ReactNode, SetStateAction, useState} from 'react';

export type User = {
    username: string
}

export interface UserContextInterface {
    user: User
    setUser: Dispatch<SetStateAction<User>>
}

const defaultState = {
    user: {
        username: '',
    },
    setUser: (user: User) => {
    }
} as UserContextInterface
export const UserContext = createContext(defaultState)


type UserProvideProps = {
    children: ReactNode
}
export default function UserProvider({children}: UserProvideProps) {
    const [user, setUser] = useState<User>({
        username: '', 
    });
    return (
        <UserContext.Provider value={{user, setUser}}>
            {children}
        </UserContext.Provider>
    )
}
