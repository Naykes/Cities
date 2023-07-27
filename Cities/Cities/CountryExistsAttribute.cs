using AutoMapper.Configuration;
using Cities.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Cities;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class CountryExistsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
    {
        IRegionRepository _regionRepository = (IRegionRepository)validationContext.GetService(typeof(IRegionRepository));
        string? country = value as string;

        bool result = _regionRepository.Query.Any(r => r.Country == country);

        if(result)
            return ValidationResult.Success;

        return new ValidationResult(this.ErrorMessage);
    }

    public override string FormatErrorMessage(string name)
    {
        return String.Format(CultureInfo.CurrentCulture,
          ErrorMessageString, name);
    }
}
