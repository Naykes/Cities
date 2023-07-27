using Cities.Models;

namespace Cities.Repositories;

public class RegionRepository : IRegionRepository
{
    private readonly CitiesContext _citiesContext;

    public RegionRepository(CitiesContext citiesContext)
    {
        _citiesContext = citiesContext;
    }

    public IQueryable<Region> Query => _citiesContext.Regions;
}
