using AutoMapper;
using Cities.Models;
using Cities.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cities.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CityService(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public Task AddCityAsync(City city)
    {
        return _cityRepository.Add(city);
    }

    public Task<List<City>> GetCitiesInRegionAsync(string region)
    {
        return _cityRepository.Query.Include(c => c.Region).Where(c => c.Region!.Name == region).ToListAsync();
    }

    public async Task<City_dto?> GetCityAsync(string city_dto)
    {
        City? city = await _cityRepository.Query.Include(c => c.Region).SingleOrDefaultAsync(c => c.Name.ToLower() == city_dto.ToLower());

        return _mapper.Map<City_dto?>(city);
    }

    public async Task<City_dto> GetRandomCityAsync()
    {
        int count = await _cityRepository.Query.CountAsync();

        int random = new Random(DateTime.Now.Millisecond).Next(0, count);

        City city = await _cityRepository.Query.Include(c => c.Region).OrderBy(c => c.Id).Skip(random).FirstAsync();

        return _mapper.Map<City_dto>(city);
    }
}
