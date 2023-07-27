using Cities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly CitiesContext _citiesContext;

    public CitiesController(CitiesContext citiesContext)
    {
        _citiesContext = citiesContext;
    }

    [HttpGet(Name = "test")]
    public List<Region> Index()
    {
        _citiesContext.Database.EnsureCreated();


        List<Region> regions = _citiesContext.Regions.ToList();
        List<City> cities = _citiesContext.Cities.ToList();
         
        return regions;
    }
}
