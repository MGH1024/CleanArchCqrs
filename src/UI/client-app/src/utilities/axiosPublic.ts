import axios from 'axios'
import {Get} from "../services/localStorageService";

const GetAuthorizationHeader = () => {
    let token = Get('token');
    if (token)
        return `Bearer ${token}`;
    return null;
}


const axiosPublic = axios.create({
    baseURL: process.env.REACT_APP_API_BASEURL,
    timeout: 3000,
    headers: {
        "Content-Type": "application/json",
        // "Authorization": GetAuthorizationHeader()
    },
});

axiosPublic.interceptors.request.use((config) => {
    let tokenHeader = GetAuthorizationHeader();
    if (tokenHeader) {
        config.headers["Authorization"] = tokenHeader;

    }
    config.headers["Access-Control-Allow-Origin"] = '*';
    config.headers["Access-Control-Allow-Headers"] = '*';
    config.headers["Access-Control-Allow-Credentials"] = true;

    return config;
}, function (error) {
    // Do something with request error
    return Promise.reject(error);
});

axiosPublic.interceptors.response.use((response) => {
    return response;
}, (error) => {
    if (error.name === "AxiosError")
        window.location.href = "/";
    if (error.response.status === 401 || error.response.status === 404) {
        localStorage.clear();
        window.location.href = "/";
    }
    return Promise.reject(error);
});

export default axiosPublic;