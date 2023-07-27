using AutoMapper;
using Cities.Models;

namespace Cities;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<City, City_dto>()
			.ForMember(c => c.Region, opt => opt.MapFrom(src => src.Region.Name));
	}
}
