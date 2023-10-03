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
            CreateMap<ArtistCreateDto, SocialNetwork>();
            CreateMap<ArtistCreateDto, Crew>();
            CreateMap<ArtistCreateDto, Artist>();
            CreateMap<ArtistCreateDto, UserRegistrerDto>();
            CreateMap<ArtistDto, Artist>().ReverseMap();
            CreateMap<AlbumDto, Album>().ReverseMap();
            CreateMap<RecordDto, Record>().ReverseMap();
            CreateMap<BrandDto, Brand>().ReverseMap();
        }
    }
}