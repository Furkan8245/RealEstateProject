using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var value = _authService.Login(userForLoginDto);
            if (!value.Success)
            {
                return BadRequest(value.Message);
            }
            var result = _authService.CreateAccessToken(value.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var value = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest();
        }

    }
}
