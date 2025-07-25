using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class Department
    {
        // ID is primary key by default
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public ICollection<Employee>? Employees { get; set; }

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

