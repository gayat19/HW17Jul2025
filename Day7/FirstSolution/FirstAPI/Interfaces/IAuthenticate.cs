using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IAuthenticate
    {
        public AddEmployeeResponseDTO RegisterEmployee(AddEmployeeRequestDTO employee);
        public LoginResponseDTO Login(LoginRequestDTO loginRequest);
    }
}
