import ISignIn from "../types/auth/signIn";
import {Set, Remove} from './localStorageService';
import axiosUtility from "../utilities/axiosUtility";
import IAuthResponse from "../types/auth/authRespose";
import ICurrentUser from "../types/auth/currentUser";

export const Login = async (values: ISignIn): Promise<IAuthResponse> => {
    return new Promise((resolve, reject) => {
        axiosUtility({
            method: 'post',
            url: '/api/authentication/signin',
            data: {
                username: values.username,
                password: values.password,
                rememberMe: values.rememberMe
            }
        })
            .then((res) => {
                resolve(res.data);
                if (res.status === 200) {
                    Set("token", res.data.Token);
                    Set("validDate", res.data.TokenValidDate);
                }
            })
            .catch((err) => {
                reject(err);
                Remove("token");
                Remove("validDate")
            });
    })
}

export const GetCurrentUserByToken = async (token: string) : Promise<ICurrentUser> => {
    const getUserByTokenUrl = "/api/authentication/get-user-by-token";
    return new Promise((resolve, reject) => {
        axiosUtility.get(getUserByTokenUrl, {params: {token: token}})
            .then((res) => {
                if(res.data.Success)
                    resolve(res.data.Data);
            })
            .catch((err) => reject(err));
    })
}

export async function Logout() {
    Remove('my-app-store');
    Remove('validDate');
    Remove('token');
}