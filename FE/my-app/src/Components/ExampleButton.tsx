import { useState } from "react";
import { fetchUserData } from "../Services/ProductApiService";

export default function ExampleButton() {
    const [msg, setMsg] = useState("Hello");
    const handleClick = () => {
        // fetchUserData().then((response)=>{
        //     setMsg(response.firstName);
        // })
        setMsg("Button Clicked");
    };
    
    return (
        <div>
        <button onClick={handleClick} className="btn btn-primary">
        Click Me
        </button>
        {msg && <p>{msg}</p>}
        </div>)
    }