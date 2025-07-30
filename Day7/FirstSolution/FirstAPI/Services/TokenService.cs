using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration) 
        {
            string secret = configuration["Tokens:JWT"] ?? "".ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
        public string GenerateToken(TokenUser user)
        {
            //Payload
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role),
            };
            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature);
            //loading the token details
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = creds,

                
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            //generating the token
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
