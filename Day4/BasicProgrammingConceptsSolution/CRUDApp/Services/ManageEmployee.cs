using CRUDApp.Exceptions;
using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Services
{
    public class ManageEmployee
    {
        List<Employee> employees;
        public ManageEmployee()
        {
            employees = new List<Employee>();
        }
        public bool AddEmployee(Employee employee)
        {
            int id = GenerateNextId();
            employee.Id = id;
            employees.Add(employee);
            return true;
        }
        public bool DeleteEmployee(int employeeID)
        {
            var employee = GetEmployeeById(employeeID);
            employees.Remove(employee);
            return true;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var employeeCheck = GetEmployeeById(employee.Id);
            if(employeeCheck != null)
            {
                employeeCheck.Name = employee.Name;
                employeeCheck.Email = employee.Email;
                employee.DateOfBirth = employee.DateOfBirth;
                employee.PhoneNumber = employee.PhoneNumber;
                employee.Image = employee.Image;
            }
            throw new NoSuchEntityException();
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            if(employees.Any())
                return employees;
            throw new NoEntriessInCollectionException();
        }

        public Employee? GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e=>e.Id==id);
            if(employee == null)
                throw new NoSuchEntityException();
            return employee;
        }
        private int GenerateNextId()
        {
            if (employees.Count == 0)
                return 101;
            var employeeId = employees.Max(x => x.Id);
            return ++employeeId;

        }
    }
}
