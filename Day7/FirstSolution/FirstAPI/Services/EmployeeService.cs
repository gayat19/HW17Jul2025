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
        private readonly IRepository<int, EmployeeStatusMaster> _employeeStatusMaster;
        private readonly IMapper _mapper;
        IRepository<int, Department> _departmentRepository;
        public EmployeeService(IRepository<int, Employee> employeeRepository,
        IRepository<int, Department> departmentRepository,
         IRepository<int, EmployeeStatusMaster> employeeStatusMaster,
        IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _employeeStatusMaster = employeeStatusMaster;
            _mapper = mapper;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            Department department=null;
            try
            {
               department = await _departmentRepository.GetById(employee.Department.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (department == null)
            {
                //employee.Department.Id = GenerateNextDepartmentId();
                employee.Department.Status = 1;
                employee.Department = await _departmentRepository.Add(employee.Department);
                employee.DepartmentId = employee.Department.Id;
                employee.Department = null;
            }
            else
            {
                if (department.Status != 1)
                    department = null;
                employee.DepartmentId = department.Id;
                employee.Department = null;
            }
               
            //employee.Id = GenerateNextEmployeeId();
            employee = await _employeeRepository.Add(employee);
            return employee;
        }
       
        public async Task<Department> GetDepartmentWiseEmployees(int departmentId)
        {
            var department = await _departmentRepository.GetById(departmentId);
            if (department == null)
                throw new NoSuchEntityException();
            var employees = await _employeeRepository.GetAll();
            if (employees == null || employees.Count() == 0)
                throw new NoEntriessInCollectionException();
            var departmentemployee = employees.Where(e => e.Department.Id == departmentId).ToList();
            if (departmentemployee == null || departmentemployee.Count() == 0)
                throw new NoEntriessInCollectionException();
            department.Employees = employees.ToList();
            return department;
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            if (employees == null || employees.Count() == 0)
                throw new NoEntriessInCollectionException();
            return employees.ToList();
        }

        public async Task<ICollection<EmployeeSerachResponseDTO>> SeachEmployees(EmployeeSearchRequestDto request)
        {
            var employees = await _employeeRepository.GetAll();
            employees = employees.Where(e => e.Status == 1);//To check on the employee active status
            if (employees.Count() > 0 && request.PhoneNumber != null)
                employees = await SearchEmployeeByPhone(employees, request.PhoneNumber);
            if (employees.Count() > 0 && request.Name != null)
                employees = await SeacrhEmployeeByName(employees, request.Name);
            if(employees.Count() > 0 && request.Departments != null && request.Departments.Count()>0)
                employees = await SerchByDepartmnets(employees, request.Departments);
            if(employees.Count() > 0 && request.DateOfBirth != null)
                employees = await SearchEmployeesByDOB(employees, request.DateOfBirth);
            if(employees.Count()>0 && request.Sort !=0)
               employees =  await SortEmployee(employees, request.Sort);
            if (employees.Count() > 0)
            {
                var result = await PopulateDepartmentName(employees);
                return result;
            }
            throw new Exception("No result found");
        }

        private async Task<ICollection<EmployeeSerachResponseDTO>> PopulateDepartmentName(IEnumerable<Employee> result)
        {
           var data = new List<EmployeeSerachResponseDTO>();
            foreach (var employee in result)
            {
                var employeeRes = _mapper.Map<EmployeeSerachResponseDTO>(employee);
                employeeRes.Department_Name = (await _departmentRepository.GetById(employee.DepartmentId)).Name;
                data.Add(employeeRes);
            }
            return data;
        }

        private async Task<IEnumerable<Employee>> SortEmployee(IEnumerable<Employee> employees, int sort)
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

        private async Task<IEnumerable<Employee>> SearchEmployeesByDOB(IEnumerable<Employee> employees, SearchRange<DateTime> dateOfBirth)
        {
            var result = employees.Where(emp => emp.DateOfBirth >= dateOfBirth.MinValue && emp.DateOfBirth <= dateOfBirth.MaxValue).ToList();
            return result;
        }

        private async Task<IEnumerable<Employee>> SearchEmployeeByPhone(IEnumerable<Employee> employees, string phoneNumber)
        {
            var result = employees.Where(emp => emp.PhoneNumber == phoneNumber).ToList();
            return result;
        }

        private async Task<IEnumerable<Employee>> SerchByDepartmnets(IEnumerable<Employee> employees, List<int> departments)
        {
            var result = new List<Employee>();
            foreach (var dep in departments) 
                result.AddRange(employees.Where(e => e.DepartmentId == dep).ToList());
            return result;
        }

        private async Task<IEnumerable<Employee>> SeacrhEmployeeByName(IEnumerable<Employee> employees, string name)
        {
            name = name.ToLower();
            var result = employees.Where(emp => emp.Name.ToLower().Contains(name)).ToList();
            return result;
        }

        public async Task<EmployeeAddResponseDTO> GetDataForAddingEmployee()
        {
            EmployeeAddResponseDTO employeeAddResponseDTO = new EmployeeAddResponseDTO();
            var status = await _employeeStatusMaster.GetAll();
            employeeAddResponseDTO.EmployeeStatuses =  _mapper.Map<ICollection<EmployeeStatusDTO>>(status);
            var departmnets = await _departmentRepository.GetAll();
            employeeAddResponseDTO.Departments = _mapper.Map<ICollection<GetDepartmnetsDTO>>(departmnets);
            return employeeAddResponseDTO;

        }
    }
}
