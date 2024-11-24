using Microsoft.AspNetCore.Mvc;
using TaskManager.Shared.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel loginModel)
        {
            if (loginModel.Username == "user" && loginModel.Password == "password")
            {
                TokenModel token = _tokenService.GenerateToken(loginModel.Username);

                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
