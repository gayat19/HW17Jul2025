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
        public Task<ICollection<Employee>> GetEmployees();
        public Task<Department> GetDepartmentWiseEmployees(int departmentId);

        public Task<Employee> AddEmployee(Employee employee);

        public Task<EmployeeAddResponseDTO> GetDataForAddingEmployee ();

       



    }
}
