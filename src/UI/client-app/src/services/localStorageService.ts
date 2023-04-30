import IUserToken from "../types/userToken";

export function Set(key: string, value: IUserToken) {
    try {
        localStorage.setItem(key, JSON.stringify(value))    
    }
    catch (err) {}
}

export function Get(key: string) {
    const value = localStorage.getItem(key);
    if(value){
        return JSON.parse(value);
    }
}

export function Remove(key: any) {
    return localStorage.removeItem(key);
}