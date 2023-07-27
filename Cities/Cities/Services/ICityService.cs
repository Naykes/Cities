using Cities.Models;

namespace Cities.Services;

public interface ICityService
{
    public Task<City_dto?> GetCityAsync(string city_dto);
    public Task AddCityAsync(City city);
    public Task<City_dto> GetRandomCityAsync();
    public Task<List<City>> GetCitiesInRegionAsync(string region);
}
