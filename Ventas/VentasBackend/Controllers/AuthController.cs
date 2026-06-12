using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ventas.Shared.DTO;

using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthUnitOfWork _authUnitOfWork;
    private readonly IConfiguration _configuration;

    public AuthController(
        IAuthUnitOfWork authUnitOfWork,
        IConfiguration configuration)
    {
        _authUnitOfWork = authUnitOfWork;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        var cliente = await _authUnitOfWork.LoginAsync(
            model.Email,
            model.Password);

        if (cliente == null)
        {
            return Unauthorized("Credenciales incorrectas");
        }

        var key = Encoding.UTF8.GetBytes(
            _configuration["jwtKey"]!
        );

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,
                cliente.Id.ToString()),

            new Claim(ClaimTypes.Email,
                cliente.Email),

            new Claim(ClaimTypes.Name,
                cliente.Nombre)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new
        {
            token = tokenString,
            clienteId = cliente.Id,
            carritoId = cliente.Carrito?.Id,
            nombre = cliente.Nombre,
            email = cliente.Email
        });
    }
}