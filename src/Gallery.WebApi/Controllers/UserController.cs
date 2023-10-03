using Gallery.Application.Utils;
using Gallery.Persistance.Dtos.Users;
using Gallery.Persistance.Validations.Users;
using Gallery.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        private readonly int maxPageSize = 30;

        public UserController(IUserService service)
        {
            this._service = service;
        }

        [HttpPut("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
        {
            var validator = new UserUpdateValidation();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(userId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, maxPageSize)));

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long userId) => Ok(await _service.DeleteAsync(userId));

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long userId) => Ok(await _service.GetByIdAsync(userId));

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new Paginationparams(page, maxPageSize)));
    }
}