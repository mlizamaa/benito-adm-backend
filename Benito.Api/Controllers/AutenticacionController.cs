using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Despensa;
using Benito.Model.Dto.Despensa;
using Benito.Model.Entities.Despensa;
using Benito.Negocio;
using Benito.Negocio.Managers.Despensa;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;


using Microsoft.AspNetCore.Mvc;
namespace Benito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;

        public AutenticacionController(IConfiguration configuration)
        {
            _configuration = configuration;
         //   _configuration.GetSection("Jwt:Key").Value = "claveSecreta";
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AutenticacionDto userLogin)
        {
            // Validar las credenciales del usuario aquí (este es solo un ejemplo)
            if (userLogin.Usuario == "test" && userLogin.Password == "password")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("68a59d75-6ac4-4ae2-8725-4c2fef066aa7"); // Asegúrate de que esta clave esté en tu appsettings.json
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "test")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}
      