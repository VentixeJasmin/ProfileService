using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(ProfileService profileService) : ControllerBase
{
    private readonly ProfileService _profileService = profileService;

    [HttpGet("form-data")]
    public IActionResult GetProfileFormData()
    {
        try
        {
            ProfileDto dto = new();
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile(ProfileDto dto)
    {
        try
        {
            var result = await _profileService.CreateProfile(dto, "");
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProfiles()
    {
        var profiles = await _profileService.GetAllProfiles();

        if (profiles != null)
        {
            return Ok(profiles);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfileByUserName(string userName)
    {
        var profile = await _profileService.GetProfileByUserName(userName);

        if (profile != null)
        {
            return Ok(profile);
        }
        else
        {
            return NotFound();
        }
    }
}
