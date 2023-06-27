using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Guid userId, string userName, string firstName, string lastName, string email, string role)
        {
            var signInCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["TokenKey"])),
                SecurityAlgorithms.HmacSha256
                );

            var claims = new[]
            {
                new Claim("Id", userId.ToString()),
                new Claim("UserName", userName),
                new Claim("FirstName", firstName),
                new Claim("LastName", lastName),
                new Claim("Email", email),
                new Claim(ClaimTypes.Role, role)
            };

            var securityToken = new JwtSecurityToken(
                issuer: null,
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: signInCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
