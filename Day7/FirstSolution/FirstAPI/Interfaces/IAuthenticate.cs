using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IAuthenticate
    {
        public Task<AddEmployeeResponseDTO> RegisterEmployee(AddEmployeeRequestDTO employee);
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
    }
}
