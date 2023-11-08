using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Notes.Application.Common.Interfaces.Authentication;
using Notes.Application.Common.Interfaces.Services;

namespace Notes.Infrastructure.Authentication;

public class JwtTokenGenerator : ITokenGenerator
{

    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(Guid userId, string firstName, string LastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256 
        );
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: _dateTimeProvider.UtcNow.AddHours(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials,
            audience: _jwtSettings.Audience
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}