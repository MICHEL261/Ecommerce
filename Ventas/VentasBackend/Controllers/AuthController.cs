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
        var usuario = await _authUnitOfWork.LoginAsync(
            model.Email,
            model.Password);

        if (usuario == null)
        {
            return Unauthorized("Credenciales incorrectas");
        }

        var key = Encoding.UTF8.GetBytes(
            _configuration["jwtKey"]!);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Rol.Nombre)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new
        {
            token = tokenString,

            usuarioId = usuario.Id,

            rol = usuario.Rol.Nombre,

            clienteId = usuario.Cliente?.Id,

            carritoId = usuario.Cliente?.Carrito?.Id,

            tiendaId = usuario.Tienda?.Id,

            nombre = usuario.Cliente != null
                ? usuario.Cliente.Nombre
                : usuario.Tienda?.Nombre,

            apellido = usuario.Cliente?.Apellido,

            email = usuario.Email,

            telefono = usuario.Cliente?.Telefono ?? usuario.Tienda?.Telefono,

            direccion = usuario.Cliente?.Direccion ?? usuario.Tienda?.Direccion
        });
    }
}