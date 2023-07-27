namespace Cities.Models;

public class Region
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public List<City> Cities { get; set; }
}
