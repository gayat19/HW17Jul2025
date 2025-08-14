import logo from './logo.svg';
import './App.css';
import Login from './Components/Login/Login';
import 'bootstrap/dist/css/bootstrap.css';
import NavBar from './Components/Navbar/Navbar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './Components/HOme/Home';

import Employees from './Components/Employees/Employees';

function App() {
  return (
    <div>
        <BrowserRouter>
           <NavBar/>
           <Routes>
            <Route path='/' element={<Home/>}/>
            <Route path='login' element ={<Login/>}/>
             <Route path='emp' element ={<Employees/>}/>
           </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
