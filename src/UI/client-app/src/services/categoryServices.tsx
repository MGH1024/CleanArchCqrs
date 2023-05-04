import axiosUtility from "../utilities/axiosUtility";
import IGetCategoryById from "../types/getCategoryById";
import ICategoryList from "../types/categoryList";
import ICategory from "../types/categoryList";

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