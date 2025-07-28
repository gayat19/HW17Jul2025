using AutoMapper;
using Azure.Core;
using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class EmployeeService : IEmployeeService, IEmployeeDashboardService
    {
        IRepository<int, Employee> _employeeRepository;
        private readonly IMapper _mapper;
        IRepository<int, Department> _departmentRepository;
        public EmployeeService(IRepository<int, Employee> employeeRepository,
        IRepository<int, Department> departmentRepository,
        IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
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
                //employee.Department.Id = GenerateNextDepartmentId();
                _departmentRepository.Add(employee.Department);
            }
            //employee.Id = GenerateNextEmployeeId();
            _employeeRepository.Add(employee);
            return employee;
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

        public ICollection<EmployeeSerachResponseDTO> SeachEmployees(EmployeeSearchRequestDto request)
        {
            var employees = _employeeRepository.GetAll();
            if (employees.Count() > 0 && request.PhoneNumber != null)
                employees = SearchEmployeeByPhone(employees, request.PhoneNumber);
            if (employees.Count() > 0 && request.Name != null)
                employees = SeacrhEmployeeByName(employees, request.Name);
            if(employees.Count() > 0 && request.Departments != null && request.Departments.Count()>0)
                employees = SerchByDepartmnets(employees, request.Departments);
            if(employees.Count() > 0 && request.DateOfBirth != null)
                employees = SearchEmployeesByDOB(employees, request.DateOfBirth);
            if(employees.Count()>0 && request.Sort !=0)
               employees =  SortEmployee(employees, request.Sort);
            if (employees.Count() > 0)
            {
                var result = PopulateDepartmentName(employees);
                return result;
            }
            throw new Exception("No result found");
        }

        private ICollection<EmployeeSerachResponseDTO> PopulateDepartmentName(IEnumerable<Employee> result)
        {
           var data = new List<EmployeeSerachResponseDTO>();
            foreach (var employee in result)
            {
                var employeeRes = _mapper.Map<EmployeeSerachResponseDTO>(employee);
                employeeRes.Department_Name = _departmentRepository.GetById(employee.DepartmentId).Name;
                data.Add(employeeRes);
            }
            return data;
        }

        private IEnumerable<Employee> SortEmployee(IEnumerable<Employee> employees, int sort)
        {
            switch (sort)
            {
                case -3:
                    employees = employees.OrderByDescending(e => e.Id); break;
                case -2:
                    employees = employees.OrderByDescending(e => e.Name); break;
                case -1:
                    employees = employees.OrderByDescending(e => e.DepartmentId); break;
                case 1:
                    employees = employees.OrderBy(e=>e.Id); break;
                case 2:
                    employees = employees.OrderBy(e => e.Name); break;
                case 3:
                    employees = employees.OrderBy(e => e.DepartmentId); break;
                default:
                    break;
            }
            return employees;
        }

        private IEnumerable<Employee> SearchEmployeesByDOB(IEnumerable<Employee> employees, SearchRange<DateTime> dateOfBirth)
        {
            var result = employees.Where(emp => emp.DateOfBirth >= dateOfBirth.MinValue && emp.DateOfBirth <= dateOfBirth.MaxValue).ToList();
            return result;
        }

        private IEnumerable<Employee> SearchEmployeeByPhone(IEnumerable<Employee> employees, string phoneNumber)
        {
            var result = employees.Where(emp => emp.PhoneNumber == phoneNumber).ToList();
            return result;
        }

        private IEnumerable<Employee> SerchByDepartmnets(IEnumerable<Employee> employees, List<int> departments)
        {
            var result = employees.Where(emp => departments.Contains(emp.Id)).ToList();
            return result;
        }

        private IEnumerable<Employee> SeacrhEmployeeByName(IEnumerable<Employee> employees, string name)
        {
            name = name.ToLower();
            var result = employees.Where(emp => emp.Name.ToLower().Contains(name)).ToList();
            return result;
        }
    }
}
