using Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cities.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CitiesContext _citiesContext;
        public CityRepository(CitiesContext citiesContext)
        {
            _citiesContext = citiesContext;
            _citiesContext.Database.EnsureCreated();
        }

        public IQueryable<City> Query => _citiesContext.Cities;

        public async Task Add(City city)
        {
            using var transaction = await _citiesContext.Database.BeginTransactionAsync();

            try
            {
                _citiesContext.Cities.Add(city);
                await _citiesContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
