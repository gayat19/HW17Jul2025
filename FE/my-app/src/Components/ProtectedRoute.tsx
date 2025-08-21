
import { Navigate } from "react-router-dom"
import { useAuth } from "../Misc/AuthContext"


const ProtectedRoute = ({children}:any)=>{
    const {isLoggedIn} = useAuth();
    if(!isLoggedIn)
        return <Navigate to="/login" replace/>
    return children
}

export default  ProtectedRoute