import { useQuery } from "@tanstack/react-query";
import { fetchProducts } from "../Services/ProductApiService";
import { ProductModel } from "../Models/ProductModel";

const ProductWithReactQuery =()=>{

const {data,isLoading,isError,error} = useQuery({
    queryKey:['products'],
    queryFn: fetchProducts
})

if(isLoading)return<p>Loading.... </p>

if(isError) return<p>Error : {error.message}</p>

return(<section>

    {
        data.map((product:ProductModel)=>(
            <div key={product.id as any} style={{border:'1px solid lightblue', margin:'10px'}}>
                <h1>{product.title}</h1>
                <p>${product.price as any}</p>

            </div>)
        )
    }
</section>)
}

export default ProductWithReactQuery;