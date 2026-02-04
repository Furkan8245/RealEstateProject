using Business;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            var value = _userService.GetAll();
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var value = _userService.GetById(id);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(User user)
        {
            var value = _userService.Update(user);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest();
        }
    }
}
