using Microsoft.AspNetCore.Mvc;
using UsernameValidationService.Services;

namespace UsernameValidationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsernameController : ControllerBase
    {
        private readonly IUsernameService _service;

        public UsernameController(IUsernameService service)
        {
            _service = service;
        }

        [HttpGet("exists/{username}")]
        public async Task<IActionResult> UsernameExists(string username)
        {
            var exists = await _service.UsernameExistsAsync(username);
            return Ok(new { username, exists });
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] UsernameDto dto)
        {
            if (!_service.IsValidUsername(dto.Username))
                return BadRequest("Invalid username format.");

            var result = await _service.AddOrUpdateUsernameAsync(dto.AccountId, dto.Username);
            if (!result)
                return Conflict("Username already exists or invalid.");

            return Ok("Username registered/updated successfully.");
        }
    }

    public class UsernameDto
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
