using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;

        public AuthenticationController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost("Register")]
        public ActionResult<AddEmployeeResponseDTO> Register(AddEmployeeRequestDTO requestDTO)
        {
            try
            {
                var result = _authenticateService.RegisterEmployee(requestDTO);
                return Created("",result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorObjectDTO { ErrorNumber = 430, ErrorMessage = ex.Message });
            }
        }
        [HttpPost("Login")]
        public ActionResult<LoginResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            try
            {
                var result = _authenticateService.Login(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorObjectDTO { ErrorNumber = 401, ErrorMessage = "Invalid username or password" });
            }
        }
    }
}
