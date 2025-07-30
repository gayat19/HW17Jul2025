using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDashboardService _dashboardService;

        public EmployeeController(IEmployeeService employeeService,IEmployeeDashboardService dashboardService)
        {
            _employeeService = employeeService;
            _dashboardService = dashboardService;
        }

        [HttpGet("GetAddMaster")]
        public ActionResult<EmployeeAddResponseDTO> AddResponse()
        {
            var result = _employeeService.GetDataForAddingEmployee();
            return result;
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

        [Route("SearchEmployee")]
        [HttpPost]
        [Authorize]
        public ActionResult<EmployeeSerachResponseDTO> Search(EmployeeSearchRequestDto requestDto)
        {
            try
            {
                var result = _dashboardService.SeachEmployees(requestDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<List<Employee>> Get()
        {
            try
            {
                var result = _employeeService.GetEmployees();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }
}
