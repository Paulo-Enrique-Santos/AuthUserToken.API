using HomeBrokerSimulator.Domain.Interface.Authentication;
using HomeBrokerSimulator.Domain.Model.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeBrokerSimulator.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        dynamic ITokenGenerator.TokenGenerator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.IdUser.ToString())
            };

            var expires = DateTime.Now.AddMinutes(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoAuthentication.API"));

            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return token;
        }
    }
}
