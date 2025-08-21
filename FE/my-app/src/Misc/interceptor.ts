import axios from "axios";


const axiosIntercepted = axios.create();

axiosIntercepted.interceptors.request.use(
  (config) => {
  const token = localStorage.getItem("token");
  if(token){
    config.headers.Authorization = `Bearer ${token}`;
  }
    return config;
  },
  (error) => {
    console.error("Request Interceptor Error", error);
    return Promise.reject(error);
  }
);

export default axiosIntercepted;