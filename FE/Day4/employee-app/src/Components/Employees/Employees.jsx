import { useEffect, useState } from "react"
import { SearchEmployees } from "../../services/employee.service"

const Employees=()=>{
    const [employees,setEmployees] = useState([])
   
    useEffect(()=>{
         const searchObject = {
            "name": "mu",
            "departments": [
                1,2,3
            ],
            "phoneNumber": "string",
            "pageNumber": 1,
            "pageSize": 2,
            "sort": 1
            }
        SearchEmployees(searchObject)
        .then((result)=>{
            setEmployees(result.data)
        })
        .catch(err=>{
            console.error(err)
        })

        return(()=>{})

    },[])
    return(<>
    {
        employees.length === 0 && (<div> No result</div>)
        
    }
    {
        employees.map((employee)=><section key={employee.id}>
            {employee.id}
        </section>)
    }

    </>)
}