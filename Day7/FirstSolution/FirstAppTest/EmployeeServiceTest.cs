using AutoMapper;
using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;
using FirstAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppTest
{
    public  class EmployeeServiceTest
    {
        IRepository<int, Department> _departmentrepository;
        IRepository<int, DepartmnetStatusMaster> _statusRepository;
        IRepository<int,EmployeeStatusMaster> _statusMasterRepository;
        IRepository<int, Employee> _employeeReository;
        [SetUp]
        public async Task Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<EmployeeManagementContext>()
               .UseInMemoryDatabase(databaseName: "Testing")
               .Options;
            EmployeeManagementContext context = new EmployeeManagementContext(dbOptions);
            _departmentrepository = new DepartmentRepositoryDb(context);
            _statusRepository = new DepartmentStatusRepository(context);
            _statusMasterRepository = new EmployeeStatusRepository(context);
            _employeeReository = new EmployeeRepositoryDB(context);
            await _statusRepository.Add(new DepartmnetStatusMaster { Status = "Available" });
            Department department = new Department()
            {
                Name = "UnitTest2",
                Status = 1
            };
            await _departmentrepository.Add(department);
            await _departmentrepository.Add(new Department { Name = "Unit Test2", Status = 1 });
            await _statusMasterRepository.Add(new EmployeeStatusMaster { Status = "Active" });
            await _employeeReository.Add(new Employee { Status=1,DepartmentId = 1,Name="test1",PhoneNumber="1234567890",Email="test1@abc.com"});
            await _employeeReository.Add(new Employee { Status = 1, DepartmentId = 1, Name = "test2", PhoneNumber = "1234567890", Email = "test2@abc.com" });
            await _employeeReository.Add(new Employee { Status = 1, DepartmentId = 2, Name = "test3", PhoneNumber = "1234567890", Email = "test3@abc.com" });
        }

        [Test]
        public async Task EmployeeSearchTest()
        {
            //Arrange
             Mock<IMapper> mapper = new Mock<IMapper>();
             mapper.Setup(m=>m.Map<EmployeeSerachResponseDTO>(It.IsAny<Employee>()))
                .Returns((Employee e)=>new EmployeeSerachResponseDTO { Id= e.Id,Name=e.Name,Email=e.Email,Phone=e.PhoneNumber });

            IEmployeeDashboardService employeeDashboardService = new EmployeeService(_employeeReository,_departmentrepository,
                                                                    _statusMasterRepository, mapper.Object);

            //Action
            var searchObject = new EmployeeSearchRequestDto
            {
                Name = "test",
                Departments = new List<int> { 1 },
                Sort = 1
            };
            var result = await employeeDashboardService.SeachEmployees(searchObject);
            //Assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        [TestCase("testCheck",1)]
        [TestCase("test11", 1)]
        public async Task EmployeeSearchExceptionTest(string name,int order)
        {
            //Arrange
            Mock<IMapper> mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<EmployeeSerachResponseDTO>(It.IsAny<Employee>()))
               .Returns((Employee e) => new EmployeeSerachResponseDTO { Id = e.Id, Name = e.Name, Email = e.Email, Phone = e.PhoneNumber });

            IEmployeeDashboardService employeeDashboardService = new EmployeeService(_employeeReository, _departmentrepository,
                                                                    _statusMasterRepository, mapper.Object);

            //Action
            var searchObject = new EmployeeSearchRequestDto
            {
                Name = name,
                Departments = new List<int> { 1 },
                Sort = order
            };
            //Assert
            Assert.ThrowsAsync<Exception>(()=>employeeDashboardService.SeachEmployees(searchObject));
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
