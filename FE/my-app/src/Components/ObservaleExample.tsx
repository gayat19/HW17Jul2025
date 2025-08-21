import { useEffect, useState } from "react";
import { fromEvent, map } from "rxjs";

const ObservaleExample =()=>{
    const [count,setCount] = useState(0);
    useEffect(()=>{
        const button =document.getElementById("btnClick")
        const click$ = fromEvent(button as any,'click')
                        .pipe(map(()=>10))//data emission
        
        const subscription = click$.subscribe((num:number)=>{
            setCount(count+num)//Action to be performed
        });

        //when the component is destroyed
        return()=> subscription.unsubscribe();
    },[count]);
    return(<div>
        <button id="btnClick" className="btn btn-success">Click to see change</button>
        <p>Click count : {count}</p>
    </div>)
}

export default ObservaleExample;