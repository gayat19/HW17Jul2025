using FirstAPI.Filters;
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
    [CustomExceptionFilter]
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
        public async Task<ActionResult<EmployeeAddResponseDTO>> AddResponse()
        {
            throw new NotImplementedException();
            var result = await _employeeService.GetDataForAddingEmployee();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            //try
            //{
                var result = await _employeeService.AddEmployee(employee);
                return Created("",result);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return BadRequest(e.Message);
            //}
            
        }

        [Route("SearchEmployee")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EmployeeSerachResponseDTO>> Search(EmployeeSearchRequestDto requestDto)
        {
            try
            {
                var result = await _dashboardService.SeachEmployees(requestDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            try
            {
                var result = await _employeeService.GetEmployees();
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
