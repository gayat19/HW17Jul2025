import { BehaviorSubject } from "rxjs";


const userSubject = new BehaviorSubject(null);

export const userlogin =(username)=>{

    userSubject.next(username);
}

export const logout =()=>{
   sessionStorage.clear("token")
   sessionStorage.clear("username")
    userSubject.next(null);
}

export const user$ = userSubject.asObservable();