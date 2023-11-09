using API.CoreModels;
using API.DTOs;
using AutoMapper;

namespace API.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //AutoMapper hat ein Problem mit dem Constructor? Dass Password wird in Klartext gesetzt.
            CreateMap<UserRequestDto, User>()
               .ConstructUsing(src => new User(null, src.Name, src.Password));
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
