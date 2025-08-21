import { useState } from "react";
import { UserModel } from "../Models/UserModel";
import { userLogin } from "../Services/AuthenticationAPIService";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../Misc/AuthContext";

const Login = ()=>{
        const [user,setUser]= useState(new UserModel("emilys","emilyspass"));
        const {login} = useAuth();
        const navigate = useNavigate();
        // const populateUser=(event:any)=>{
        // const element = event.target;
        //     if(element.name=='username')
        //     {
        //         setUser({...user,username:element.value})
               
        //     }
        //     if(element.name=='password')
        //     {
        //         setUser({...user,password:element.value})
        //     }
        // }
    const handleLogin =()=>{
        event.preventDefault();
         userLogin(user)
         .then((response)=>{
            if(response.status==200)
            {
                alert('login success');
                //localStorage.setItem('token',response.data.accessToken)
                login(response.data.accessToken);
                navigate('/obs')
            }
         })
            
    }
    return(<div>
        <form>

            <button onClick={handleLogin} className="btn btn-primary">Login</button>
        </form>
    </div>)
}

export default Login;