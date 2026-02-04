using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            var value = _cityService.Add(city);
            return value.Success ? Ok(value) : BadRequest(); //Neden böyle yaptık: Çünkü bize neyden dolayı başarılı veya başarısız olduğunu söyleyen bir IResult dönüyor.
        }
        [HttpPut("update")]
        public IActionResult Update(City city)
        {
            var value = _cityService.Update(city);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(City city)
        {
            var value = _cityService.Delete(city);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var value = _cityService.GetById(id);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var value = _cityService.GetAll();
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("exists")]
        public IActionResult Exists(int id)
        {
            var value = _cityService.Exists(id);
            return value.Success ? Ok(value): BadRequest();
        }
     

    }
}
