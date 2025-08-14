

import { useEffect, useState } from "react"
import { SearchEmployees } from "../../services/employee.service"


const Employees=()=>{
        useEffect(()=>{
         const searchObject = {
            "name": "mu",
         
            "pageNumber": 1,
            "pageSize": 2,
            "sort": 1
            }
        SearchEmployees(searchObject)
        .then((result)=>{
            //alert('done');
            console.log(result.data)
           setEmployees(result.data.employees??[])
        })
        .catch(err=>{
            console.error(err)
        })

        console.log('Mounted')

    },[])
    const [employees,setEmployees] = useState([])
    


    if (!employees || employees.length === 0) return <div>No result</div>;
    return(<>
    {
        employees.map((employee)=><section key={employee.id}>
            {employee.name}
        </section>)
    }

    </>)
}

export default Employees;