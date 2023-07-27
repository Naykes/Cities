using Cities.Models;
using Cities.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public Task<City_dto> GetRandom()
    {        
        return _cityService.GetRandomCityAsync();
    }

    [HttpPost]
    public async Task<IActionResult> PostCity([FromBody] City city)
    {
        city.Id = 0;

        Task task = _cityService.AddCityAsync(city);

        await task;
        
        if(task.IsCompletedSuccessfully)
            return Ok();

        return BadRequest();
    }

    [HttpGet]
    [Route("city_dto")]
    public Task<City_dto?> GetCity([FromQuery]string city_dto)
    {
        return _cityService.GetCityAsync(city_dto);
    }

    [HttpGet]
    [Route("region")]
    public Task<List<City>> GetRegion([FromQuery] string region)
    {
        return _cityService.GetCitiesInRegionAsync(region);
    }

}
