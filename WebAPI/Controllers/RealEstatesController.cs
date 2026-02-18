using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealEstatesController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstatesController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _realEstateService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getmine")]
        public IActionResult GetMine()
        {
            int userId = GetUserIdFromToken();
            var result = _realEstateService.GetAllByUserId(userId);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Geçersiz ID");

            var result = _realEstateService.GetById(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] RealEstateAddDto dto)
        {
            if (dto == null)
                return BadRequest("Boş veri gönderilemez.");

            var result = _realEstateService.Add(dto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] RealEstateUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Boş veri gönderilemez.");

            var result = _realEstateService.Update(dto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] RealEstateDeleteDto dto)
        {
            if (dto == null)
                return BadRequest("Boş veri gönderilemez.");

            var result = _realEstateService.Delete(dto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyfilter")]
        public IActionResult GetByFilter([FromQuery] RealEstateFilterDto filterDto)
        {
            var result = _realEstateService.GetByFilter(filterDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbydistrict")]
        public IActionResult GetByDistrict(int districtId)
        {
            if (districtId <= 0)
                return BadRequest("Geçersiz districtId");

            var result = _realEstateService.GetAllByDistrictId(districtId);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                throw new Exception("Token içinde UserId bulunamadı.");

            return int.Parse(userIdClaim.Value);
        }
    }
}
