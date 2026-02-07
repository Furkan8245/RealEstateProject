using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaAnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AreaAnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }
        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] AreaAnalysisDto areaAnalysisDto)
        {
            var value = _analysisService.CalculateAndSave(areaAnalysisDto);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var value=_analysisService.GetAll();
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(AreaAnalysisDeleteDto analysisDeleteDto)
        {
            var value= _analysisService.Delete(analysisDeleteDto);
            if (value.Success)
            {
                return Ok(value);            
            }
            return BadRequest(value);
        }
        [HttpPost("update")]
        public IActionResult Update(AreaAnalysisUpdateDto areaAnalysisUpdate)
        {
            var value = _analysisService.Update(areaAnalysisUpdate);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var value = _analysisService.GetById(id);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
    }
}
