import IUserToken from "../types/userToken";

export function Set(key: string, value: IUserToken) {
    localStorage.setItem(key, JSON.stringify(value))
}

export function Get(key: string) {
    return localStorage.getItem(key)
}

export function Remove(key: any) {
    return localStorage.removeItem(key);
}