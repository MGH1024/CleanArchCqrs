import axios from "axios";

//const API_URL = "http://localhost:8080/api/auth/";


const API_URL = process.env.REACT_APP_API_BASEURL
class AuthService {
  login(username: string, password: string,rememberMe:boolean) {
    debugger;
    return axios
      .post(API_URL+"/api/authentication/signin", {
        username,
        password,
        rememberMe
      })
      .then(response => {
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(username: string, email: string, password: string) {
    return axios.post(API_URL + "signup", {
      username,
      email,
      password
    });
  }

  getCurrentUser() {
    const userStr = localStorage.getItem("user");
    if (userStr) return JSON.parse(userStr);

    return null;
  }
}

export default new AuthService();
