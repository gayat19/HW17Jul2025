using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUDApp.Models
{
    //Open and Closed principle - not editing the parent method instead inheriting and changing teh functionality
    public class DepartmentEmployees : Department
    {
        public override string ToString()
        {
            var data = new StringBuilder($"Departmnet Id  : {Id}\nDepartment Name : {Name}");
            if (Employees != null && Employees.Count > 0)
            {
                data.Append("\n---------------------------\n");
                foreach (Employee emp in Employees)
                {
                    data.Append(emp);
                    data.Append("\n***********************\n");
                }
            }

            return data.ToString();
        }
    }
}
