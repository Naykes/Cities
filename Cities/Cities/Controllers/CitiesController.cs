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

    [HttpGet(Name = "test")]
    public Task<City_dto> Index()
    {        
        return _cityService.GetRandomCityAsync();
    }

    [HttpPost(Name = "test1")]
    public async Task<IActionResult> Post([FromBody] City city)
    {
        city.Id = 0;

        Task task = _cityService.AddCityAsync(city);

        await task;
        
        if(task.IsCompletedSuccessfully)
            return Ok();

        return BadRequest();
    }

    [HttpGet]
    [Route("/test2/{City_dto}")]
    public Task<City_dto?> Get(string City_dto)
    {
        return _cityService.GetCityAsync(City_dto);
    }

    [HttpGet]
    [Route("/test3/{region}")]
    public Task<List<City>> Get3(string region)
    {
        return _cityService.GetCitiesInRegionAsync(region);
    }

}
