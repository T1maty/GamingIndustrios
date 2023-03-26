using AutoMapper;
using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Incoming;

namespace GamingIndustrios.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverCreationDto, Driver>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.FirstName} ")
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => $"{src.LastName}")
            )
            .ForMember(
                dest => dest.WorldChampionships,
                opt => opt.MapFrom(src => src.WorldChampionships)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1)
            )
            .ForMember(
                dest => dest.DriverNumber,
                opt => opt.MapFrom(src => src.DriverNumber)
            );
        }
    }
}
