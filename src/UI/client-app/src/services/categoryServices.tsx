import axiosUtility from "../utilities/axiosUtility";
import IGetCategoryById from "../types/getCategoryById";

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