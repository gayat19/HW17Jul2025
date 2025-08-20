import { configureStore } from "@reduxjs/toolkit";
import authReducer from './authSlicer';


export const store = configureStore({
    name:'auth',
    reducer:authReducer
})