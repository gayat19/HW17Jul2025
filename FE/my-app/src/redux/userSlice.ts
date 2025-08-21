// import { createSlice } from "@reduxjs/toolkit";
// import { jwtDecode } from "jwt-decode";


// interface JwtPayload{
//     exp?: number;
//     iat?: number;
//     sub?: string;
//     name?: string;
//     email?: string;
//     role?: string;
// }
// type AuthContextType ={
//     user: JwtPayload | null;
//     isLoggedIn:boolean;
  
// }
// const userSlice = createSlice({
//     name: "user",
//     initialState: {
//         user: {
//             user:  ,
//             isLoggedIn: false;
          
//         },
//         isLoggedIn: false,
//     },
//     reducers: {
//         login:(state,action)=>{
//             const decodedUser = jwtDecode<JwtPayload>(action.payload);
//             localStorage.setItem("token",action.payload.token);
//             state.user = decodedUser;
//             state.isLoggedIn = true;
//         },
//         logout:(state)=>{
//             localStorage.removeItem("token");
//             state.user=null;
//             state.isLoggedIn = false;
//         },
//         initialize:(state)=>{
//             const token = localStorage.getItem("token");
//             if(!token)
//                 return;
        
//                 try{
//                     const decodedUser = jwtDecode(token);
//                     if(decodedUser.exp && decodedUser.exp < Date.now()/1000){
//                         state.user = null;
//                         state.isLoggedIn = false;
//                         localStorage.removeItem("token");
//                     }
//                 }
//                 catch(e){
//                     console.error("Error decoding token", e);
        
//             }
//         }
//         }
// })

// export const {login,logout,initialize} = userSlice.actions;
// export default userSlice.reducer;