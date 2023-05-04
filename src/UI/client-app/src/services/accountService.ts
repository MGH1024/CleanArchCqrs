import ISignIn from "../types/signIn";
import {Set, Remove} from './localStorageService';
import axiosUtility from "../utilities/axiosUtility";
import IGetUserByToken from "../types/getUserByToken";

export const Login = async (values: ISignIn) => {
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
                if (res.status === 200) {
                    resolve(res);
                    const {appSession} = res.data;

                    if (!appSession?.Token) {
                        Remove("token");
                        Remove("validDate");
                    }
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

export async function GetCurrentUserByToken(token: string | null) {
    const getUserByTokenUrl = "/api/authentication/get-user-by-token";
    return new Promise<IGetUserByToken>((resolve, reject) => {
        axiosUtility.get(getUserByTokenUrl, {params: {token: token}})
            .then((res: any) => {
                resolve(res);
            })
            .catch((err) => reject(err));
    })
}

export async function Logout() {
    Remove('my-app-store');
    Remove('validDate');
    Remove('token');
}