
import axios from "axios";

export function loginAPICall(loginModel)
{
    return axios.post("http://localhost:5064/api/Authentication/Login",loginModel)
}