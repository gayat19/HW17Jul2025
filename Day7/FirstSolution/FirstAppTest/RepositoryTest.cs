using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAppTest
{
    public class RepsitoryTests
    {
         IRepository<int,Department> _departmentrepository;
        IRepository<int,DepartmnetStatusMaster> _statusRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<EmployeeManagementContext>()
               .UseInMemoryDatabase(databaseName: "Testing")
               .Options;
            EmployeeManagementContext context = new EmployeeManagementContext(dbOptions);
            _departmentrepository = new DepartmentRepositoryDb(context);
            _statusRepository = new DepartmentStatusRepository(context);
        }

        [Test]
        public async Task AddDepartmentTest()
        {
            //Arrange
            await _statusRepository.Add(new DepartmnetStatusMaster { Status = "Available" });
            Department department = new Department()
            {
                Name = "Unit Test",
                Status = 1
            };

            //Action
            var result = await _departmentrepository.Add(department);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown() 
        { 
        }
    }
}