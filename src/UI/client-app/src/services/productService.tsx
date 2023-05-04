import IAddProduct from "../types/product/addProduct";
import axiosUtility from "../utilities/axiosUtility";
import IGetProductById from "../types/product/getProductById";
import IProduct from "../types/product/product";

export const CreateCategory = async (value: IAddProduct) => {
    return new Promise((resolve, reject) => {
        axiosUtility({
            method: 'post',
            url: '/api/products/create-product',
            data: {
                code: value.code,
                title: value.title,
                quantity: value.quantity,
                categoryId:value.categoryId,
                description: value.description,
            }
        })
            .then((res) => {
                debugger;
                resolve(res);
            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const GetProducts = async () => {
    const url = '/api/products';
    return new Promise((resolve, reject) => {
        axiosUtility({
            url: url,
            method: 'get',
        })
            .then((res) => {
                resolve(res.data.Data);
            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const GetProductById = async (value: IGetProductById) : Promise<IProduct> => {
    return new Promise((resolve, reject) => {
        axiosUtility({
            method: 'get',
            url: '/api/products/get-product-by-id',
            params: {
                Id: value.id
            }
        })
            .then((res) => {
                resolve(res.data.Data);
            })
            .catch((err) => {
                reject(err);
            });
    })
}