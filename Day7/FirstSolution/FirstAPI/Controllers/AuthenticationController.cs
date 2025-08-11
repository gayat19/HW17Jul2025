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
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticate authenticateService,ILogger<AuthenticationController> logger)
        {
            _authenticateService = authenticateService;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AddEmployeeResponseDTO>> Register(AddEmployeeRequestDTO requestDTO)
        {
            try
            {
                var result = await _authenticateService.RegisterEmployee(requestDTO);
                return Created("",result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorObjectDTO { ErrorNumber = 430, ErrorMessage = ex.Message });
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO requestDTO)
        {
            try
            {
                var result = await _authenticateService.Login(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unauthorized access done by username " + requestDTO.Username);
                return Unauthorized(new ErrorObjectDTO { ErrorNumber = 401, ErrorMessage = "Invalid username or password" });
            }
        }
    }
}
