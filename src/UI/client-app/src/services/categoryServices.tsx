import IGetCategoryById from "../types/getCategoryById";
import axiosPublic from "../utilities/axiosPublic";

export const GetCategoryById = async (value: IGetCategoryById) => {
    const url = '/api/categories/get-category-by-id';
    return new Promise((resolve, reject) => {
        axiosPublic({
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