import axios from 'axios'

export const axiosPublic= axios.create({
    baseURL:process.env.REACT_APP_API_BASEURL,
    timeout: 1000,
    headers: {
        "Content-Type": "application/json"
    },
});