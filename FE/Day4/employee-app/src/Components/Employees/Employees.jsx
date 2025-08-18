

import { useEffect, useState } from "react"
import { SearchEmployees } from "../../services/employee.service"
import Employee from "./Employee"


const Employees=()=>{
    const [likecount,setLikecount] = useState(0);
    var likes = [];
        useEffect(()=>{
         const searchObject = {
            "name": "mu",
         
            "pageNumber": 1,
            "pageSize": 2,
            "sort": 1
            }
        SearchEmployees(searchObject)
        .then((result)=>{
           setEmployees(result.data.employees??[])
        })
        .catch(err=>{
            console.error(err)
        })



    },[])

    const likeChange = (id)=>{
        let flag = false;
        for(let i=0;i<likes.length;i++)
        {
            if(id==likes[i])
            {
                flag =true;
                break;
            }
        }
        if(!flag)
        {
            likes.push(id);
            setLikecount(likes.length);
        }
    }
    const [employees,setEmployees] = useState([])
    


    if (!employees || employees.length === 0) return <div>No result</div>;
    return(<>
     {  
        employees.map((employee)=><section key={employee.id}>
           <Employee employee={employee} onLikeClick={(eid)=>likeChange(eid)} />
        </section>)
    }
    <hr/>
     <div>Number od liked employees - {likecount}</div>
    </>)
}

export default Employees;