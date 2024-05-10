using BibliotecaAuth.DTOs;
using BibliotecaAuth.Models;
using BibliotecaAuth.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Proyectos_WebApi.NETCore8.Connection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly ApiDbContext _context;
        public readonly AuthPassword authPassword;

        public AuthController(IConfiguration configuration, ApiDbContext context)
        {
            _context = context;
            _configuration = configuration;
            authPassword = new AuthPassword();
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<ActionResult<dynamic>> IniciarSesion(
            [FromForm] AuthLoginDTO login,
            CancellationToken cancellationToken)
        {
            var usuario = await _context.AuthUsuario
                .Include(e => e.AuthPerfil)
                .SingleOrDefaultAsync(e => e.Email == login.Email, cancellationToken);
            
            if(usuario == null)
                return Unauthorized();

            if (!authPassword.VerifyPassword(login.Clave, usuario.AuthHash, usuario.AuthSalt))
                return Unauthorized();

            var jwt = _configuration.GetSection("JWT").Get<AuthJwt>()!;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Name, login.Email),
                new Claim(JwtRegisteredClaimNames.Email, login.Email),
                new Claim(ClaimTypes.Role, usuario.AuthPerfil.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIng = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: jwt.Issuer,
                    audience: jwt.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwt.ExpireMin)),
                    signingCredentials: singIng
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<ActionResult<dynamic>> Registrarse(
            [FromForm] AuthRegisterDTO register,
            CancellationToken cancellationToken)
        {
            if (register.Clave1 != register.Clave2)
                return BadRequest(new { Mensaje = "Las Contraseñas no Coinciden" });

            var existeUsuario = _context.AuthUsuario.Any(e => e.Email == register.Email);
            if (existeUsuario)
                return BadRequest(new { Mensaje = "El Usuario ya Existe" });

            (string Hash, string Salt) = authPassword.HashPassword(register.Clave1);

            var newUser = new AuthUsuarioModel
            {
                Id = Guid.NewGuid().ToString(),
                Email = register.Email.ToLower(), 
                Usuario = register.Email.ToLower(),
                AuthHash = Hash,
                AuthSalt = Salt,
                IdPerfil = 2,
            };

            _context.AuthUsuario.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new { Mensaje = "Usuario Creado Correctamente" });
        }
    }
}
