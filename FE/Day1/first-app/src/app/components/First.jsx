"use client";

import { useState } from "react";
import './First.css';

export default function First(){
    //var name = "Ramu";
    const [name,setName] = useState("Ramu")//hook
    const [product,setProduct] = useState();
    const change = ()=>{
       //setName("Somu");
       fetch('https://dummyjson.com/products/1')
       .then((rawaData)=>rawaData.json())
       .then(data=>{
        setProduct(data);
      
    })
       
    }
    return(<div>
            <button className="btn btn-success" onClick={()=>change()}>Get Product Data</button>
            <div className="card cardDiv" >
            <img className="card-img-top" src={product?.thumbnail} alt="Card image cap"/>
            <div className="card-body">
                <h5 className="card-title">{product?.title}</h5>
                <p className="card-text">{product?.description}</p>
                <a href="#" className="btn btn-primary">Buy for {product?.price}</a>
            </div>
            </div>
        </div>);
}