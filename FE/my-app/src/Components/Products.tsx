import { useEffect, useState } from "react";
import { getProducts } from "../Services/ProductApiService";
import Product from "./Product";
import { ProductModel } from "../Models/ProductModel";

import './Product.css'


const Products=()=>{
    const [products,setProducts] = useState([])
    useEffect(()=>{
       getProducts()
       .then(data=>{
            setProducts(data.data);
       })
       .catch(error=>{
             console.log(error)
       })
    },[])
return(
    <div className="container">
        <h1>Products</h1>
        {
            products.length>0?
            products.sort((a:ProductModel,b:ProductModel)=>
                a.title.localeCompare(b.title))
            .map((product:ProductModel)=>
            <Product key={product.id as any} product={product} />)
            :null
        }
    </div>
)
}

export default Products;