using Gallery.Application.Utils;
using Gallery.Persistance.Dtos.Images;
using Gallery.Persistance.Validations.Images;
using Gallery.Service.Interfaces.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.WebApi.Controllers;

[Route("api/images")]
[ApiController]
public class ImageController : ControllerBase
{
    private IImageService _servise;
    private readonly int maxPageSize = 30;

    public ImageController(IImageService service)
    {
        this._servise = service;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromForm] ImageCreateDto dto)
    {
        var validator = new ImagesCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _servise.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _servise.CountAsync());

    [HttpGet("{imageId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long imageId) => Ok(await _servise.GetByIdAsync(imageId));

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1) =>
        Ok(await _servise.GetAllAsync(new Paginationparams(page, maxPageSize)));

    [HttpDelete("{imageId}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAsync(long imageId) => Ok(await _servise.DeleteAsync(imageId));

    [HttpPut("{imageId}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateAsync(long imageId, [FromForm] ImageUpdateDto dto)
    {
        var validator = new ImageUpdateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _servise.UpdateAsync(imageId, dto));
        else return BadRequest(result.Errors);
    }
}