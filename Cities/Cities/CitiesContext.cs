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
            r.HasData(new Region() { Name = "Afryka", Country = "RPA" });
            r.HasData(new Region() { Name = "Afryka", Country = "Nigeria" });
            r.HasData(new Region() { Name = "Afryka", Country = "Kenia" });

            r.HasData(new Region() { Name = "Azja", Country = "Japonia" });
            r.HasData(new Region() { Name = "Azja", Country = "Chiny" });
            r.HasData(new Region() { Name = "Azja", Country = "Indie" });
            r.HasData(new Region() { Name = "Azja", Country = "Tajlandia" });
            
            r.HasData(new Region() { Name = "Europa", Country = "Niemcy" });
            r.HasData(new Region() { Name = "Europa", Country = "Francja" });
            r.HasData(new Region() { Name = "Europa", Country = "Włochy" });
            r.HasData(new Region() { Name = "Europa", Country = "Polska" });
            
            r.HasData(new Region() { Name = "Ameryka północna", Country = "USA" });
            r.HasData(new Region() { Name = "Ameryka północna", Country = "Kanada" });
            r.HasData(new Region() { Name = "Ameryka północna", Country = "Meksyk" });

        });


        modelBuilder.Entity<City>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasOne(c => c.Region).WithMany(r => r.Cities).HasForeignKey(c => c.Country);

            c.HasData(new City() { Name = "Kair", Country = "Egipt", Population = 10m, Id = 1 });
            c.HasData(new City() { Name = "Kapsztad", Country = "RPA", Population = 5m, Id = 2 });

            c.HasData(new City() { Name = "Tokio", Country = "Japonia", Population = 15m, Id = 3 });
            c.HasData(new City() { Name = "Pekin", Country = "Chiny", Population = 15m, Id = 4 });
            
            c.HasData(new City() { Name = "Berlin", Country = "Niemcy", Population = 8m, Id = 5 });
            c.HasData(new City() { Name = "Warszawa", Country = "Polska", Population = 2m, Id = 6 });
            
            c.HasData(new City() { Name = "New York", Country = "USA", Population = 10m, Id = 7 });
            c.HasData(new City() { Name = "Meksyk", Country = "Meksyk", Population = 20m, Id = 8 });
        });
    }
}
