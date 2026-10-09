using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GastroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        //var username = _configuration["AdminAuth:Username"];
        //var password = _configuration["AdminAuth:Password"];

        var username = "admin";
        var password = "MeinSicheresPasswort123!";

        // Demo-Authentifizierung: Zugangsdaten aus User Secrets prüfen.
        if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password) ||
            request.Username != username ||
            request.Password != password)
        {
            return Unauthorized(new
            {
                message = "Benutzername oder Passwort ist falsch."
            });
        }

        var jwt = _configuration.GetSection("Jwt");
        var key = jwt["Key"]
            ?? throw new InvalidOperationException("JWT-Key fehlt.");

        var issuer = jwt["Issuer"]
            ?? throw new InvalidOperationException("JWT-Issuer fehlt.");

        var audience = jwt["Audience"]
            ?? throw new InvalidOperationException("JWT-Audience fehlt.");

        var expireMinutes = int.TryParse(
            jwt["ExpireMinutes"], out var minutes)
            ? minutes
            : 60;

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            signingKey,
            SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddMinutes(expireMinutes);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new
        {
            accessToken = tokenString,
            tokenType = "Bearer",
            expiresAtUtc = expires
        });
    }
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}