using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public ICollection<Employee>? Employees { get; set; }

        public override string ToString()
        {            
            return $"Departmnet Id  : {Id}\nDepartment Name : {Name}";
        }

    }
}
