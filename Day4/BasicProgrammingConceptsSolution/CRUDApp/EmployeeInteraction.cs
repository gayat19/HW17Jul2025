using CRUDApp.Exceptions;
using CRUDApp.Interfaces;
using CRUDApp.Models;
using CRUDApp.Repositories;
using CRUDApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp
{
    public class EmployeeInteraction
    {
        IRepository<int, Employee> _employeeRepository;
        IRepository<int, Department> _departmentRepository;
        IEmployeeService _employeeService;
        public EmployeeInteraction()
        {
            _departmentRepository = new DepartmentRepository();
            _employeeRepository = new EmployeeRepository();
            _departmentRepository.Add(new Department { Id = 1, Name = "Bench" });
            _employeeService = new  EmployeeService(_employeeRepository,_departmentRepository);
        }
        public void PrintMenu()
        {
            Console.WriteLine("Welcome to Subakur COmpany");
            Console.WriteLine("Please select from the options");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Department wise Employees");
            Console.WriteLine("3. Print all the emloyees");
            Console.WriteLine("0 : Exit");
        }
        public void StartInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye ....");
                        break;
                    case 1:
                        Add();
                        break;
                     case 2:
                        PrintDepartment();
                        break;
                    case 3:
                        PrintAllEmployees();
                        break;
                    default:
                        Console.WriteLine("Invaid choice");
                        break;
                }
            }
            while (choice !=0);
        }

        private void PrintAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAll();
                PrintAll<Employee>(employees);
            }
            catch (NoEntriessInCollectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int PrintDepartmentsAndGetSelectedID()
        {
            var departmnets = _departmentRepository.GetAll();
            PrintAll<Department>(departmnets);
            Console.WriteLine("slect a department id");
            int id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for dpartmnet Id");
            }
            return id;
        }

        private void PrintDepartment()
        {
            try
            {
                int id = PrintDepartmentsAndGetSelectedID();
                var depatment = _employeeService.GetDepartmentWiseEmployees(id);
                Print<DepartmentEmployees>((DepartmentEmployees)depatment);
            }
            catch (NoSuchEntityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEntriessInCollectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Add()
        {
            try
            {
                Employee employee = TakeEmployeeDetailsFromConsole();
                employee = AddDepartmentDetails(employee);
                _employeeService.AddEmployee(employee);
            }
            catch(NoSuchEntityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NoEntriessInCollectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Print<T>(T item)
        {
            Console.WriteLine(item);
        }
        public void PrintAll<T>(IEnumerable<T> items)
        {
            if(items == null || items.Count() == 0)
            {
                Console.WriteLine("No Employees");
                return;
            }
            foreach (var item in items)
            {
                Print<T>(item);
                Console.WriteLine("=================================");
            }
        }
        public Employee TakeEmployeeDetailsFromConsole()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the employee name");
            employee.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter the employee Date of Birth");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Pelase enter employee E-Mail");
            employee.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Pelase enter employee Phone");
            employee.PhoneNumber = Console.ReadLine() ?? "";
            Console.WriteLine("Pelase enter employee Image Link");
            employee.Image = Console.ReadLine() ?? "";
            return employee;
        }
        public Employee AddDepartmentDetails(Employee employee)
        {
            var departments = _departmentRepository.GetAll();
            PrintAll<Department>(departments);
            Console.WriteLine("Please select the department");
            Console.WriteLine("If you want to add the department as new one please enter 0");
            int id = PrintDepartmentsAndGetSelectedID();
            if (id == 0)
            {
                Console.WriteLine("Please enter the new Departnet's name");
                employee.Department.Name = Console.ReadLine() ?? "";
            }
            else
            {
                employee.Department.Id = id;
            }
            return employee;
        }
        
    }
}
