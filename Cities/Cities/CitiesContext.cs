using Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cities;

public class CitiesContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Region> Regions { get; set; }

    public CitiesContext(DbContextOptions options) : base(options)
    { 

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>(r =>
        {

            r.HasKey(x => x.Country);
            r.HasMany(r => r.Cities).WithOne(c => c.Region)
            .HasForeignKey(r => r.Country);



            r.HasData(new Region() { Name = "Afryka", Country = "Egipt" });
        });


        modelBuilder.Entity<City>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasOne(c => c.Region).WithMany(r => r.Cities).HasForeignKey(c => c.Country);

            c.HasData(new City() { Name = "Test", Country = "Egipt", Population = 1m, Id = 1 });
        });
    }
}
