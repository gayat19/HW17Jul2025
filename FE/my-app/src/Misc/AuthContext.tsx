import { jwtDecode } from "jwt-decode";
import { createContext, useContext, useEffect, useState } from "react"

interface JwtPayload{
    exp?: number;
    iat?: number;
    sub?: string;
    name?: string;
    email?: string;
    role?: string;
}


interface AuthContextType {
    user: JwtPayload | null;
    isLoggedIn:boolean;
    login: (token: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType|undefined>(undefined);

export const AuthProvider = ({children}:any)=>{
    const [user,setUser] = useState<JwtPayload|null>(null);

    const login = (token:string)=>{
        try{
            const decodedUser = jwtDecode<JwtPayload>(token);
            localStorage.setItem("token",token);
            setUser(decodedUser);
        }
            catch(e){
                console.error("Error decoding token", e);
            }   
        }
    const logout = ()=>{
        localStorage.removeItem("token");
        setUser(null);
    }
useEffect(()=>{

    const token = localStorage.getItem("token");
    if(!token)
        return;

        try{
            const decodedUser = jwtDecode(token);
            if(decodedUser.exp && decodedUser.exp < Date.now()/1000){
                logout();
            }
        }
        catch(e){
            console.error("Error decoding token", e);

    }


},[])
return(
    <AuthContext.Provider value={{user,isLoggedIn:!!user,login,logout}}>
        {children}
    </AuthContext.Provider>
)

};
export const useAuth =()=>{
    const context = useContext(AuthContext);
    if(!context){
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
}
