using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Mapper{
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegistrerDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLisDto>();
            CreateMap<SocialNetworkDto, SocialNetwork>();
            CreateMap<CrewDto, Crew>();
        }
    }
}