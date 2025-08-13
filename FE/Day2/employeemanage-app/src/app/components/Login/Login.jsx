'use client';

import { useState } from "react";
import './Login.css';
import { LoginModel } from "@/models/login.model";
import { loginAPICall } from "@/app/services/login.service";

const Login = ()=>{
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");

    const changeUsername =(eventArgs)=>{
      
        setUsername(eventArgs.target.value)
    }
    const changePassword =(eventArgs)=>{
        setPassword(eventArgs.target.value)
    }
    const login=()=>{
        var loginModel = new LoginModel();
        loginModel.username = username;
        loginModel.password = password;
        loginAPICall(loginModel)
        .then(result=>{
            console.log(result.data)
            alert("Login success");
        })
        .catch(err=>{
            console.log(err);
            if(err.status === 401)
             alert(err.response.data.errorMessage)
        })
    }
    const cancel =()=>{
        setPassword("");
        setUsername("");
    }
    return (
        <section className="loginDiv">
            <h1>Login!!</h1>
            <label className="form-control">Username</label>
            <input type="text" value={username} onChange={(e)=>changeUsername(e)} className="form-control"/>
              <label className="form-control">Password</label>
            <input type="password" value={password} onChange={(e)=>changePassword(e)} className="form-control"/>
            <button className="button btn btn-success" onClick={login}>Login</button> 
            <button className= "button btn btn-danger" onClick={cancel}>Cancel</button>
        </section>
    )
}

export default Login;