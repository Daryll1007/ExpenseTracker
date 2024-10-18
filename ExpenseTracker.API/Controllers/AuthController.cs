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
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin loginModel)
        {
            // Replace with actual user lookup
            if (loginModel.Username == "admin" && loginModel.Password == "password123")
            {
                // Simulate a successful login
                return Ok("Login successful");
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }

    }

    public class UserLogin
    {
        public string Username { get; set; } // Make sure this is not nullable
        public string Password { get; set; } // Make sure this is not nullable
    }


}
