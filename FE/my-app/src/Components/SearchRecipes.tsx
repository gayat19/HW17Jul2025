import { useEffect, useState } from "react";
import { getRecipesTags, getSearchedRecipes } from "../Services/ProductApiService";
import {  fromEvent } from "rxjs";
import {debounceTime, distinctUntilChanged, map, switchMap} from 'rxjs/operators'

const SearchRecipes = ()=>{
    const [tags,setTags] = useState([])
    const [loading,setLoading] = useState(false);
    const[searchResult,setSearchResult] = useState([]);

    useEffect(()=>{
      const getData = async()=>{
        const response = await getRecipesTags();
        setTags(response.data)
      }  
      getData();
      const searchInput = document.getElementById("lstTags");

      const search$ = fromEvent(searchInput as any,'change')
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
          var data = await getSearchedRecipes(query);
          setLoading(false);
          return data.data.recipes;
        }
    return(<section>
        <select id="lstTags">
            <option defaultValue="">Select a Tag</option>
            {tags.length>0?
            tags.map((tag,index)=><option key={index} value={tag}>{tag}</option>)
            :null}
        </select> 
        {loading==true?<p>Loading...</p>:null}
              <ul>
                {searchResult.length>0?
                searchResult.map((recipe:any)=>(
                    <li key={recipe.id as any}>{recipe.name}</li>
                ))
                :null
                }
              </ul>        
    </section>)
}

export default SearchRecipes;