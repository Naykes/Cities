using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cities.Models;

public class City
{
    public int Id { get; set; } = 0;
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa nie może być pusta!")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Populacja jest wymagana!")]
    [Range(0, 100000000,ErrorMessage = "Populacja musi być dodatnia!")]
    public decimal Population { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Kraj nie może być pusty!")]
    [CountryExists(ErrorMessage = "Nie istnieje taki kraj w BD!")]
    public string Country { get; set; } = string.Empty;
    [IgnoreDataMember]
    public Region? Region { get; set; }
}
