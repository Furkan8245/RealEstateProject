using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpPost("add")]
        public IActionResult Add(District district)
        {
            var value=_districtService.Add(district);
            return value.Success? Ok(value): BadRequest(value);

        }
        [HttpPut("update")]

        public IActionResult Update(District district)
        {
            var value = _districtService.Update(district);
            return value.Success ? Ok(value) : BadRequest(value);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(District district)
        {
            var value = _districtService.Delete(district);
            return value.Success?Ok(value) : BadRequest(value);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var value= _districtService.GetById(id);
            return value.Success? Ok(value) : BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var value= _districtService.GetAll();
            return value.Success? Ok(value) :BadRequest();
        }
        [HttpGet("exists")]
        public IActionResult Exists(int id)
        {
            var value = _districtService.Exists(id);
            return (value.Success? Ok(value) : BadRequest());
        }
    }
}
