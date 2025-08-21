import axios from "axios";
import axiosIntercepted from "../Misc/interceptor";


import { QueryFunctionContext } from "@tanstack/react-query";
import { baseURL } from "../environments/environment.dev";

export function getProducts():Promise<any>{
    return axios.get("https://fakestoreapi.com/products");
}

export function getSearchedProducts(searchWord:string){
    return axios.get("https://dummyjson.com/products/search?q="+searchWord)
}

export function getRecipesTags(){
    return axios.get("https://dummyjson.com/recipes/tags")
}

export function getProductById(pid:string){
  const url = `${baseURL}product/${pid}`
  return axios.get(url);
}
export function getSearchedRecipes(searchWord:string){
    return axios.get("https://dummyjson.com/recipes/tag/"+searchWord)
}

export const fetchProducts = async()=>{
    const response = await axios.get("https://fakestoreapi.com/products");
    return response.data;
}

export const fetchUserData = async()=>{
    const response = await axiosIntercepted.get("https://dummyjson.com/auth/me");
    return response.data;
}
type ProductModel = {
    id: number
    title: string
    price: number
  }
  
  type PageResponse = {
    data: ProductModel[]
    nextPage: number
    hasMore: boolean
  }

//'https://dummyjson.com/products?limit=10&skip=10&select=title,price'
export const fetchProductsByPage = async (
  ctx: QueryFunctionContext
): Promise<PageResponse> => {
  const pageParam = (ctx.pageParam ?? 1) as number
  const response = await fetch(`https://fakestoreapi.com/products?limit=5`)
  const data = await response.json()

  return {
    data,
    nextPage: pageParam + 1,
    hasMore: pageParam < 5,
  }
}