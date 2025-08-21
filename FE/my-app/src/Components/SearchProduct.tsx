import { useEffect, useState } from "react";
import { ProductModel } from "../Models/ProductModel";
import { getSearchedProducts } from "../Services/ProductApiService";
import {  fromEvent } from "rxjs";
import {debounceTime, distinctUntilChanged, map, switchMap} from 'rxjs/operators'


const SearchProduct = ()=>{
    const [loading,setLoading] = useState(false);
    const[searchResult,setSearchResult] = useState([]);
    const[searchWord,setSearchWord] = useState("");
    useEffect(()=>{
      const searchInput = document.getElementById("searchInput");

      const search$ = fromEvent(searchInput as any,'input')
                      .pipe(map((event)=>(event as any).target.value),
                      debounceTime(500),
                      distinctUntilChanged(),
                      switchMap((query)=>searchedProducts(query)));

      const subscription = search$.subscribe({
        next:(result)=>setSearchResult(result),
        error:(err)=>console.log(err)
      })

      return()=>subscription.unsubscribe();
    },[])

    const searchedProducts = async (query:string)=>{
      if(!query.trim()){
        setSearchResult([]);
        return[]
      }
      setLoading(true);
      var data = await getSearchedProducts(query);
      setLoading(false);
      return data.data.recipes;
    }

    return(<div style={{padding:'20px'}}> 
      <h1>Search Product</h1>
      <input id="searchInput" value={searchWord} onChange={(event)=>setSearchWord(event.target.value)} type="text" style={{width:'300px',padding:'10px',fontSize:'16px'}}/>
      {loading==true?<p>Loading...</p>:null}
      <ul>
        {searchResult.length>0?
        searchResult.map((product:ProductModel)=>(
            <li key={product.id as any}>{product.title}</li>
        ))
        :null
        }
      </ul>

    </div>)
}

export default SearchProduct;