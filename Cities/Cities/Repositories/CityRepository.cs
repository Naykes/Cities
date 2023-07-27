using Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cities.Repositories;

public class CityRepository : ICityRepository
{
    private readonly CitiesContext _citiesContext;
    public CityRepository(CitiesContext citiesContext)
    {
        _citiesContext = citiesContext;
        _citiesContext.Database.EnsureCreated();
    }

    public IQueryable<City> Query => _citiesContext.Cities;

    public Task Add(City city)
    {
        _citiesContext.Cities.Add(city);
        return _citiesContext.SaveChangesAsync();
    }
}
