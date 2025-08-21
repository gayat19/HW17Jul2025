import axios from "axios";
import { baseURL } from "../environments/environment.dev";
import { UserModel } from "../Models/UserModel";

export function userLogin(login:UserModel){
   const url = `${baseURL}auth/login`
    return axios.post(url,login);

}