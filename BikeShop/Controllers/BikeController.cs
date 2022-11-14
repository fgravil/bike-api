using BikeShop.Services.Interfaces;
using BikeShop.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeController : ControllerBase
{
    private readonly IBikeService _bikeService;

    public BikeController(IBikeService bikeService)
    {
        _bikeService = bikeService;
    }

    /// <summary>
    /// Gets all bike records
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetBikes")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _bikeService.GetBikesAsync());
    }

    [HttpPost(Name = "CreateBike")]
    public async Task<IActionResult> Post([FromBody] BikeModelBase bikeRequest)
    {
        var bikeId = await _bikeService.AddBikeAsync(bikeRequest);
        return Created(new Uri($"{Request.Path}/{bikeId}", UriKind.Relative), null);
    }

    [HttpPut("{bikeId}", Name = "UpdateBike")]
    public async Task<IActionResult> Update([FromRoute] Guid bikeId, [FromBody] BikeModelBase bikeRequest)
    {
        await _bikeService.UpdateBikeAsync(bikeId, bikeRequest);
        return NoContent();
    }

    [HttpDelete("{bikeId}", Name = "DeleteBike")]
    public async Task<IActionResult> Delete([FromRoute] Guid bikeId)
    {
        await _bikeService.DeleteBikeAsync(bikeId);
        return NoContent();
    }
}

