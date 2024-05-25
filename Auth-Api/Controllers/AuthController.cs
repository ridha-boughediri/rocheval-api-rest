using AuthApi.Models;
using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var token = _authService.Authenticate(userLogin);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var registeredUser = _authService.Register(user);
            if (registeredUser == null)
            {
                return BadRequest("User already exists");
            }

            return Ok(registeredUser);
        }
    }
}
