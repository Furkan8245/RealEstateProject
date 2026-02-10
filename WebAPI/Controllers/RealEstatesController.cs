using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstatesController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }
        [HttpGet("getall")]
        public IActionResult GetAllByRole()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var role= User.FindFirst(ClaimTypes.Role)?.Value;
            var value=_realEstateService.GetAllByRole(userId,role);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var value = _realEstateService.GetById(id);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpPost("add")]
        public IActionResult Add(RealEstateAddDto realEstateAddDto)
        {
            var value = _realEstateService.Add(realEstateAddDto);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpPost("update")]
        public IActionResult Update(RealEstateUpdateDto realEstateUpdateDto)
        {
            var value = _realEstateService.Update(realEstateUpdateDto);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpPost("delete")]
        public IActionResult Delete(RealEstateDeleteDto realEstateDeleteDto)
        {
            var value = _realEstateService.Delete(realEstateDeleteDto);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }

        [HttpGet("getbyfilter")]
        public IActionResult GetByFilter([FromQuery] RealEstateFilterDto realEstateFilterDto)
        {
            var value = _realEstateService.GetByFilter(realEstateFilterDto);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }
        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            // Business katmanındaki servisini çağırıyoruz
            var result = _realEstateService.GetAllByUserId(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbydistrict")]
        public IActionResult GetByFilter(int districtId)
        {
            var value = _realEstateService.GetAllByDistrictId(districtId);
            if (value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value);
        }


    }
}
