using Cities.Models;

namespace Cities.Repositories;

public interface IRegionRepository
{
    public IQueryable<Region> Query { get; }
}
