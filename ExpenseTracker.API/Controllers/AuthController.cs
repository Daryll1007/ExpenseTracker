using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey = "YourSecretKeyHere"; // Replace with a more secure key in production

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin loginModel)
        {
            // Replace with actual user lookup
            if (loginModel.Username == "admin" && loginModel.Password == "password123")
            {
                // Create token
                var token = GenerateJwtToken(loginModel.Username);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class UserLogin
    {
        public string Username { get; set; } // Make sure this is not nullable
        public string Password { get; set; } // Make sure this is not nullable
    }
}
