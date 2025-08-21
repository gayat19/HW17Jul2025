

import 'bootstrap/dist/css/bootstrap.css';
// import ProductWithReactQuery from './Components/ProductsWithReactQuery';
// import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
// import InfiniteScrollProduct from './Components/InfiniteScrollProduct';
import { BrowserRouter,  Route, Routes } from 'react-router-dom';
import Products from './Components/Products';

import Menu from './Components/Menu';
import Login from './Components/Login';
import SingleProduct from './Components/SingleProduct';
import ProtectedRoute from './Components/ProtectedRoute';
import Profile from './Components/Profile';
import { lazy, Suspense } from 'react';
import ExampleButton from './Components/ExampleButton';




const OwnObservable = lazy(() => import('./Components/OwnObservable'));


function App() {
// const queryClient = new QueryClient();

  return (
    // <QueryClientProvider client={queryClient}>
    //     <InfiniteScrollProduct/>
    // </QueryClientProvider>
    <div>
    
      <BrowserRouter>
      <Menu/>
      <Routes>
        <Route path='/' element={<Products/>}/>
        <Route path='obs' element={
          <Suspense fallback={<div>Loading...</div>}>
            <OwnObservable/>  
          </Suspense>
        }/>
        <Route path='login' element={<Login/>}/>
        <Route path='product/:pid' element={<SingleProduct/>}/>
        <Route path='profile' element={
          <ProtectedRoute>
            <Profile/>

          </ProtectedRoute>
        }/>

         <Route path='uprofile' element={
          <ProtectedRoute>
            <ExampleButton/>
          </ProtectedRoute>
        }/>
      </Routes>
      
    </BrowserRouter>

    </div>
    
  )
}

export default App
