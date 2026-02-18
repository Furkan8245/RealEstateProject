using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Admin")] 
        public IActionResult GetAll()
        {
            var result = _auditLogService.GetAll(); 
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
