
import axios from "axios";
import {baseUrl} from '../environment.dev';

export function loginAPICall(loginModel)
{
    const url = baseUrl+'Authentication/Login';

    return axios.post(url,loginModel)
}