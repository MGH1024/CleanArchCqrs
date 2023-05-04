import IUser from "./user";
import IToast from "./toast";
import {Dispatch, SetStateAction,} from 'react';

export default interface IUserContextInterface {
    user: IUser
    showToast: IToast
    setShowToast: Function
    setUser: Dispatch<SetStateAction<IUser>>
}