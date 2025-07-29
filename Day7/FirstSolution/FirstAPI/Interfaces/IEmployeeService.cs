using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Interfaces
{
    public interface IEmployeeService
    {
        public ICollection<Employee> GetEmployees();
        public Department GetDepartmentWiseEmployees(int departmentId);

        public Employee AddEmployee(Employee employee);

        public EmployeeAddResponseDTO GetDataForAddingEmployee ();



    }
}
