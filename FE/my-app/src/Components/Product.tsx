// import { useEffect } from "react"
import { useNavigate } from "react-router-dom";
import { ProductModel } from "../Models/ProductModel";

type Props ={
    product:ProductModel,
    key:Number
}

export default function Product(args:Props){
    // useEffect(()=>{
    //     console.log(args )
    // });
    const navigate = useNavigate();
    const handleDetails =()=>{
       navigate('/product/'+args.product.id)
       // navigate(-1)
    }
    return(
        <section>
            <div className="card myCard" >
            <img className="card-img-top" src={args.product.image} alt="Card image cap" />
            <div className="card-body">
                <h5 className="card-title">{args.product.title}</h5>
                <p className="card-text">{args.product.description}</p>
                <button onClick={handleDetails}  className="btn btn-primary">Buy for {new Intl.NumberFormat("en-US",{
                    style:"currency",
                    currency:"YEN"
                }).format(args.product.price as number)} </button>

            </div>
            </div>
        </section>
    )
}