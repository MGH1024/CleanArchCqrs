import IAddProduct from "../types/product/addProduct";
import axiosUtility from "../utilities/axiosUtility";
import IGetProductById from "../types/product/getProductById";
import IProduct from "../types/product/product";
import ICommandResponse from "../types/responses/commandResponse";
import IUpdateProduct from "../types/product/updateProduct";

export const CreateProduct = async (value: IAddProduct): Promise<ICommandResponse> => {
    return new Promise((resolve, reject) => {
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
                if (res.data.Success) {
                    resolve(res.data);
                } else {
                    resolve({Id: 0, Success: false, Message: 'create product failed'})
                }

            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const UpdateProduct = async (value: IUpdateProduct): Promise<ICommandResponse> => {

    return new Promise((resolve, reject) => {

        axiosUtility({
            method: 'put',
            url: '/api/products/update-product',
            data: {
                id: value.id,
                code: value.code,
                title: value.title,
                quantity: value.quantity,
                categoryId: value.categoryId,
                description: value.description,
            }
        })
            .then((res) => {
                //resolve(res);
        
                if (res.data.Success) {
                    resolve(res.data);
                } else {
                    resolve({Id: 0, Success: false, Message: 'create product failed'})
                }

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