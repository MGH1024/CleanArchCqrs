import { axiosPublic } from "../api/axiosPublic";
import {axiosPrivate} from "../api/axiosPrivate";
import ICreateCategory from "../types/createCategory";

export async function  Create(values :ICreateCategory){
    const createPartyUrl = "/fa-ir/api/Parties";
    console.log(createPartyUrl);
    return new Promise((resolve,reject)=>{
    axiosPrivate({
        method:'post',
        url:createPartyUrl,
        data:{
            code: values.code,
            title: values.title,
            description:values.description
        }
    })
    .then((res)=>{
        resolve(res);
        console.log(res);
    })
    .catch((err)=>reject(err));
    })
}