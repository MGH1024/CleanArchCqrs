import {axiosPublic} from "../api/axiosPublic";
import {Set, Remove} from './localStorageService';
import mem from "mem";
import IGetUserByToken from "../types/GetUserByToken";


export const Login = async (values: any) => {
    debugger;
    const loginUrl = "/api/authentication/signin";
    return new Promise((resolve, reject) => {
        axiosPublic({
            method: 'post',
            url: loginUrl,
            data: {
                username: values.username,
                password: values.password,
                rememberMe: values.rememberMe
            }
        })
            .then((res) => {
                debugger;
                resolve(res);
                const {appSession} = res.data;

                if (!appSession?.Token) {
                    Remove("token");
                    Remove("validDate");
                }

                Set("token", res.data.Token);
                Set("validDate", res.data.TokenValidDate);

            })
            .catch((err) => {
                debugger;
                reject(err);
                Remove("token");
                Remove("validDate")
            });
    })
}


const maxAge = 10000;

export const memoizedToken = mem(Login, {
    maxAge,
});


export async function GetCurrentUserByToken(token: string | null) {
    const getUserByTokenUrl = "/api/authentication/get-user-by-token";
    return new Promise<IGetUserByToken>((resolve, reject) => {
        axiosPublic.get(getUserByTokenUrl, {params: {token: token}})
            .then((res: any) => {
                resolve(res);
            })
            .catch((err) => reject(err));
    })
}
 