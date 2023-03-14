using AutoMapper;
using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Incoming;

namespace GamingIndustrios.Profiles
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<ComputerCreationDto, Computer>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                dest => dest.ComputerName,
                opt => opt.MapFrom(src => $"{src.ComputerName}")
                )
                .ForMember(
                dest => dest.ComputerName,
                opt => opt.MapFrom(src => $"{src.Motherboard}")
                );

        }
    }
}