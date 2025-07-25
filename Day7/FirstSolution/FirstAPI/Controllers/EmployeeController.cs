using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            try
            {
                var result = _employeeService.AddEmployee(employee);
                return Created("",result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            
        }
    }
}
