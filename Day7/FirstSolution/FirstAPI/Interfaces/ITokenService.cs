using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(TokenUser user);
    }
}
