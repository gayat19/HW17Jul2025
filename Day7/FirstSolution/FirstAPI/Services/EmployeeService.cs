using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        IRepository<int, Employee> _employeeRepository;
        IRepository<int, Department> _departmentRepository;
        public EmployeeService(IRepository<int, Employee> employeeRepository,
        IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }
        public Employee AddEmployee(Employee employee)
        {
            Department department=null;
            try
            {
                department = _departmentRepository.GetById(employee.Department.Id);
            }
            catch (Exception ex)
            {
            }
            if (department == null)
            {
                employee.Department.Id = GenerateNextDepartmentId();
                _departmentRepository.Add(employee.Department);
            }
            employee.Id = GenerateNextEmployeeId();
            _employeeRepository.Add(employee);
            return employee;
        }

        private int GenerateNextDepartmentId()
        {
            var departments = _departmentRepository.GetAll();
            if (departments.Any())
            {
                var max = departments.Max(d=>d.Id);
                return ++max;
            }
            return 1;
        }
        private int GenerateNextEmployeeId()
        {
            var employees = _employeeRepository.GetAll();
            if (employees.Any())
            {
                var max = employees.Max(d => d.Id);
                return ++max;
            }
            return 101;
        }

        public Department GetDepartmentWiseEmployees(int departmentId)
        {
            var department = _departmentRepository.GetById(departmentId);
            if (department == null)
                throw new NoSuchEntityException();
            var employees = _employeeRepository.GetAll();
            if (employees == null || employees.Count() == 0)
                throw new NoEntriessInCollectionException();
            var departmentemployee = employees.Where(e=>e.Department.Id == departmentId);
            if (departmentemployee == null || departmentemployee.Count() == 0)
                throw new NoEntriessInCollectionException();
            department.Employees = employees.ToList();
            return department;
        }

        public ICollection<Employee> GetEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if (employees == null || employees.Count() == 0)
                throw new NoEntriessInCollectionException();
            return employees.ToList();
        }
    }
}
