import axiosUtility from "../utilities/axiosUtility";
import IGetCategoryById from "../types/category/getCategoryById";
import ICategory from "../types/category/categoryList";

export const GetCategoryById = async (value: IGetCategoryById) => {
    const url = '/api/categories/get-category-by-id';
    return new Promise((resolve, reject) => {
        axiosUtility({
            method: 'get',
            url: url,
            params: {
                Id: value.id
            }
        })
            .then((res) => {
                resolve(res);
            })
            .catch((err) => {
                reject(err);
            });
    })
}


export const GetCategories = async (): Promise<ICategory[]> => {
    const url = '/api/categories';
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