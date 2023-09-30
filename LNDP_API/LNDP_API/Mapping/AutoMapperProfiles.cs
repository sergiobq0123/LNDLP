using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Mapping{
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegistrerDto, User>();
            CreateMap<UserLoginDto, User>();
            // postArtist
            CreateMap<ArtistDto, SocialNetwork>();
            CreateMap<ArtistDto, Crew>();
            CreateMap<ArtistDto, Artist>();
            CreateMap<ArtistDto, UserRegistrerDto>();
        }
    }
}