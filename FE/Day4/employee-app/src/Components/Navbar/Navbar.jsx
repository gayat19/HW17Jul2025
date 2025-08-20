import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import { logout, user$ } from "../../rxjs/User.Change";
import { useAuth } from "../../AuthContext";
import { useSelector } from "react-redux";

export default function NavBar(){
    const [userO,setUserO] = useState(undefined);
    const {user} = useAuth();
    const userDataRedux = useSelector(state=>state.username);
   useEffect(()=>{
        const subscriber = user$;

        subscriber.subscribe(
            {
                next:(un)=>{
                    console.log(un)
                    if(un !=null)
                        setUserO(un)
                    else
                        setUserO(undefined)
                }
            }
        )

        
      
   },[]);
    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <a className="navbar-brand" href="#">Welcome - {userDataRedux}</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
            <li className="nav-item active">
                <Link to="/" className="nav-link">Home</Link>
            </li>
             <li className="nav-item active">
                <Link to="/emp" className="nav-link">Employees</Link>
            </li>
            {
                userO===undefined?(<li className="nav-item">
                <Link to="/login" className="nav-link">Login</Link>
            </li>):(<li className="nav-item">
                <Link  onClick={logout}  className="nav-link">Log-out</Link>
            </li>)
            }
            
            {/* <li className="nav-item">
                 <Link to="/products" className="nav-link">Products</Link>
            </li> */}
           
            </ul>
        </div>
        </nav>
    )
}