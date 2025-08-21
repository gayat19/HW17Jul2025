// import { useEffect } from "react"
import { useEffect, useState } from "react";
import { ProductModel } from "../Models/ProductModel";
import { useParams } from "react-router-dom";
import { getProductById } from "../Services/ProductApiService";



export default function SingleProduct(){

    const [product,setProduct] = useState(new ProductModel())
    const {pid} = useParams();
    useEffect(()=>{
        getProductById(pid as string).then((response)=>{
            if(response.status==200)
            {
                setProduct(response.data);
            }
        }).catch((err)=>{
            console.log(err)
        })
    },[pid])
    return(
        <section>
            <h2>Product Details - {pid}</h2>
            <div className="card myCard" >
            <img className="card-img-top" src={product.image} alt="Card image cap" />
            <div className="card-body">
                <h5 className="card-title">{product.title}</h5>
                <p className="card-text">{product.description}</p>
                
            </div>
            </div>
        </section>
    )
}