using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIStudent.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIStudent.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("token")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] Cred login)
        {
            IActionResult response = Unauthorized();
            var user = login.Username;
            if (user != null)
            {
                var tokenString = GenerateToken();
                response = Ok(tokenString);
            }
            return response;
        }
        
      
        public object GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiryTime = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"]));
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                expires: expiryTime,
                signingCredentials: creds);
            var details = new
            {
                tokenString = new JwtSecurityTokenHandler().WriteToken(token),
                expiryDate = expiryTime
            };
            return details;

        }
    }
}
