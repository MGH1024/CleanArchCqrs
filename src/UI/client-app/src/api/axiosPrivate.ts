import axios from "axios";
import {memoizedToken} from '../services/accountService';
import {Get} from '../services/localStorageService';


axios.defaults.baseURL=process.env.REACT_APP_API_BASEURL;
axios.interceptors.request.use(
    async (config :any) => {
        const token = Get("token");
        if (token) {
          config.headers = {
            ...config.headers,
            authorization: `Bearer ${token}`,
          };
        }
        return config;
      },
      (error) => Promise.reject(error)

)

axios.interceptors.response.use(
    (response) => response,
    async (error) => {
      const config = error?.config;
  
      if (error?.response?.status === 401 && !config?.sent) {
        config.sent = true;
  
        // const result = await memoizedToken();
        //
        // if (result) {
        //   config.headers = {
        //     ...config.headers,
        //     authorization: `Bearer ${result}`,
        //   };
        // }
        return axios(config);
      }
      return Promise.reject(error);
    }
  );
  
  export const axiosPrivate = axios;