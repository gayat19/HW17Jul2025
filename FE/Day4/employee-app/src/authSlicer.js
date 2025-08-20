import { createSlice } from "@reduxjs/toolkit";

export const authSlicer = createSlice({
    name:'auth',
    initialState:{username:null},
    reducers:{
        login:(state,action)=>{
            console.log(action.payload)
            state.username = action.payload.username;
        },
        logout:(state,action)=>{
            state.username = null
        }
    }
})

export const {login,logout} = authSlicer.actions;
export default authSlicer.reducer;