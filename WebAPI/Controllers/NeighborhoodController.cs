using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly INeighborhoodService _neighborhoodService;

        public NeighborhoodController(INeighborhoodService neighborhoodService)
        {
            _neighborhoodService = neighborhoodService;
        }
        [HttpPost("add")]
        public IActionResult Add(Neighborhood neighborhood)
        {
            var value = _neighborhoodService.Add(neighborhood);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var value = _neighborhoodService.GetAll();
            return value.Success ? Ok(value): BadRequest();
        }
        [HttpPut("update")]
        public IActionResult Update(Neighborhood neighborhood)
        {
            var value = _neighborhoodService.Update(neighborhood);
            return value.Success?Ok(value): BadRequest();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var value = _neighborhoodService.Delete(id);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var value = _neighborhoodService.GetById(id);
            return value.Success ? Ok(value) : BadRequest();
        }
        [HttpGet("exist")]
        public IActionResult Exists(int id)
        {
            var value = _neighborhoodService.Exists(id);
            return value.Success ? Ok(value) : BadRequest();
        }
    }
}
