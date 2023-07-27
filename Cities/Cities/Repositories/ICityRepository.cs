using Cities.Models;

namespace Cities.Repositories;

public interface ICityRepository
{
    public Task Add(City city);

    public IQueryable<City> Query { get; }
}
