import IAddProduct from "../types/product/addProduct";
import axiosUtility from "../utilities/axiosUtility";
import IGetProductById from "../types/product/getProductById";
import IProduct from "../types/product/product";
import ICreateProductResponse from "../types/product/createProductResponse";

export const CreateProduct = async (value: IAddProduct): Promise<ICreateProductResponse> => {
    return new Promise((resolve, reject) => {
        debugger;
        axiosUtility({
            method: 'post',
            url: '/api/products/create-product',
            data: {
                code: value.code,
                title: value.title,
                quantity: value.quantity,
                categoryId: value.categoryId,
                description: value.description,
            }
        })
            .then((res) => {
                debugger;
                if (res.data.Success)
                    resolve(res.data);
                resolve({Id: 0, Success: false, Message: 'create product failed'})
            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const GetProducts = async (): Promise<IProduct[]> => {
    return new Promise((resolve, reject) => {
        axiosUtility({
            url: '/api/products',
            method: 'get',
        })
            .then((res) => {
                if (res.data.Success)
                    resolve(res.data.Data);
                resolve([]);
            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const GetProductById = async (value: IGetProductById): Promise<IProduct> => {
    return new Promise((resolve, reject) => {
        axiosUtility({
            method: 'get',
            url: '/api/products/get-product-by-id',
            params: {
                Id: value.id
            }
        })
            .then((res) => {
                if (res.data.Success)
                    resolve(res.data.Data);
                resolve({
                    Id: 0,
                    Title: '',
                    CategoryId: 0,
                    Code: 0,
                    Order: 0,
                    CreatedDate: new Date(),
                    Quantity: 0,
                    Description: '',
                    CategoryTitle: ''
                })
            })
            .catch((err) => {
                reject(err);
            });
    })
}