using AutoMapper;
using Core.DTOs.Authentication;
using Core.Entities;

namespace Core.Helpers.Mappers
{
    public class AuthenticationMapper : Profile
    {
        public AuthenticationMapper()
        {
            CreateMap<User, RegistrationDTO>().ReverseMap()
                .ForMember(dest => dest.UserName,
                           act => act.MapFrom(src => src.Email));
        }
    }
}
