using AutoMapper;
using GamingIndustrios.Models;
using GamingIndustrios.Models.DTOs.Incoming;

namespace GamingIndustrios.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<СustomerCreationDto, Customer>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.FirstName}")
                )
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => $"{src.LastName}")
                )
                .ForMember(
                 dest => dest.PhoneNumber,
                 opt => opt.MapFrom(src => src.PhoneNumber)
                );
        }

    }
    
}
