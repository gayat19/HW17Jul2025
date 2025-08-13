'use client';

import Link from "next/link";

export default function NavBar(){
    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <a className="navbar-brand" href="#">Navbar</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
            <li className="nav-item active">
                <Link href="/" className="nav-link">Home</Link>
            </li>
            <li className="nav-item">
                <Link href="/login" className="nav-link">Login</Link>
            </li>
            <li className="nav-item">
                 <Link href="/products" className="nav-link">Products</Link>
            </li>
           
            </ul>
        </div>
        </nav>
    )
}