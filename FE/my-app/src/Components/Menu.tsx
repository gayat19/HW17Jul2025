import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../Misc/AuthContext";

export default function Menu(){
  const {user,isLoggedIn,logout} = useAuth();
  const navigate = useNavigate();
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
  <a className="navbar-brand" href="#">Navbar</a>
  <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span className="navbar-toggler-icon"></span>
  </button>
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
      <li className="nav-item active">
        <Link className="nav-link" to="/">Home</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="obs">Observable</Link>
      </li>
      {/* <li className="nav-item">
      <Link className="nav-link" to="profile">Profile</Link>
      </li> */}
      {isLoggedIn?
       <li className="nav-item">
        <Link className="nav-link" to="uprofile">Profile</Link>
      </li>:null}
    </ul>
  </div>
  <div className="form-inline">
    {!isLoggedIn?<button className="btn btn-outline-success my-2 my-sm-0" type="submit"
    onClick={()=>{
      navigate("/login"); 
  }}
    >Login</button>
    :<div>
      Hi - {user?.name}
    <button className="btn btn-outline-danger my-2 my-sm-0" type="submit" onClick={()=>{ logout();
      navigate("/login"); 
  }}>    Logout</button>
  </div>
}
  </div>
</nav>
    )
}