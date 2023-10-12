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



            // Para el artist/id de la pagina web
            CreateMap<Artist, ArtistWebDetailDto>();
            CreateMap<Song, SongWebDto>();
            CreateMap<Event, EventWebDto>();
            CreateMap<Album, GenericCardDto>();

            // Para el generic artist
            CreateMap<Artist, ArtistWebGenericDto>();
            CreateMap<SocialNetwork, SocialNetworkWebDto>();
            

            CreateMap<Event, GenericCardDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Artist.Photo))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.City + src.Location))
                .ForMember(dest => dest.WebUrl, opt => opt.MapFrom(src => src.Tickets)); 

            CreateMap<Company, CompanyIntranetDto>().ReverseMap();           
            CreateMap<CompanyType, CompanyTypeIntranetDto>().ReverseMap();
        }
    }
}