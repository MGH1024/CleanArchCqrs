import IUserToken from "../types/userToken";

export function Set(key: string, value: IUserToken) : void {
    try {
        localStorage.setItem(key, JSON.stringify(value))    
    }
    catch (err) {
        console.log(err);
    }
}

export function Get(key: string) : any {
    const value = localStorage.getItem(key);
    if(value){
        return JSON.parse(value);
    }
}

export function Remove(key: any) : void {
    localStorage.removeItem(key);
}