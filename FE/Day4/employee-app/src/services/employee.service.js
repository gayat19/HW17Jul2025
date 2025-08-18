import axios from '../Interceptors/AuthInterceptor';
import {baseUrl} from '../environment.dev';

export function SearchEmployees(searchData)
{

    const url = baseUrl+'Employee/SearchEmployee';
    return axios.post(url,searchData);
}