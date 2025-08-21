import { useEffect, useState } from "react";
import { Observable } from "rxjs";

const OwnObservable = ()=>{
    const [count,setCount] = useState(0);
    useEffect(()=>{
        const myObservable = new Observable((subscriber)=>{
            let cnt =0;
            const intervalId = setInterval(()=>{
                subscriber.next(cnt);
                cnt++;

                if(cnt>10)
                  subscriber.complete();
            },1000);

            return()=>{
                clearInterval(intervalId);
            }
        });
        const subscription = myObservable.subscribe(
            {
                next:(val:any)=>{setCount(val)},
                complete:()=>console.log("All done and cleaned up")
            }
        )
        return()=> subscription.unsubscribe();
    },[]);
    return(<div>
        count : {count}
    </div>)
}

export default OwnObservable;