using CreateWebAPI.Models;
using CreateWebAPI.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace CreateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly AuthService _authService;

        public AuthController(IConfiguration config)
        {
            _authService = new AuthService(config);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            if (user.Username == "admin" && user.Password == "pass123") // Replace with DB check
            {
                var token = _authService.GenerateJwtToken(user.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
