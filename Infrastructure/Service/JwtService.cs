using API.Settings;
using Core.Enums;
using Core.Interface.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Service;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;
    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public string GetAccessToken(string firstName, string lastName, string email, Role role)
    {

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Iss, "Buna"),
            new Claim(JwtRegisteredClaimNames.Aud, "Boy"),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("rol", role.ToString())
        };

        var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        var signingCredentials = new SigningCredentials(signingkey, SecurityAlgorithms.Sha256);

        var jwtToken = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ValidForInMinutes),
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
