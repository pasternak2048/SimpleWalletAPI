using AutoMapper;
using Domain.Entities.Identity;
using WebAPI.Models.Authentication;

namespace WebAPI.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<RegisterDto, AppUser>()
                .ForMember(e => e.Email, opt => opt.MapFrom(s => s.UserName))
                .ReverseMap();
                
        }
    }
}
