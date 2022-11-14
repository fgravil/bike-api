using BikeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupController : ControllerBase
{
    private readonly ILookupService _lookupService;

    public LookupController(ILookupService lookupService)
    {
        _lookupService = lookupService;
    }

    [HttpGet("Manufacturers", Name = "GetManufacturers")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _lookupService.GetLookupAsync("manufacturer"));
    }
}

