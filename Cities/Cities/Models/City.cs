namespace Cities.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Population { get; set; }
    public string Country { get; set; } = string.Empty;
    public Region Region { get; set; }
}
