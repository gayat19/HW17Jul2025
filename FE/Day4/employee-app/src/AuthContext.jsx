import {  createContext, useContext, useState } from "react";


const AuthContext = createContext(undefined);

export const AuthProvider = ({children})=>{
    const [user,setUser] = useState(undefined);

    const login = (username)=>setUser(username);
    const logout = ()=>setUser(undefined);

    return(
        <AuthContext.Provider value={{user,login,logout}}>
            {children}
        </AuthContext.Provider>

    )
}

export const useAuth =()=>{
    const context = useContext(AuthContext);
    if(!context)
        throw new Error("useAuth is not initiated");
    return context;
}