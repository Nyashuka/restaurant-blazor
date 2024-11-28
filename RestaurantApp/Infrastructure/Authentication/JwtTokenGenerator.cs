using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace RestaurantApp.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string Generate(int id, string role)
    {
        var signingCredential = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtTokenSettings.JwtKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var securityToken = new JwtSecurityToken(
            claims: claims,
            issuer: "RestaurantApp",
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredential
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
