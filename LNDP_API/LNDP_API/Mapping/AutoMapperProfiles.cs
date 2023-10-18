using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Utils.PasswordHasher;

namespace LNDP_API.Mapping{
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles()
        {
            // Inicio de sesión
            CreateMap<User, UserRegistrerDto>()
            .ForMember(dest => dest.UserRoleName, opt => opt.MapFrom(src => src.UserRole.Role))
            .ReverseMap();
            CreateMap<UserLoginDto, User>();

            // postArtist
            CreateMap<ArtistCreateDto, SocialNetwork>();
            CreateMap<ArtistCreateDto, Artist>();
            CreateMap<ArtistCreateDto, UserRegistrerDto>();
            CreateMap<ArtistDto, Artist>().ReverseMap();
            CreateMap<AlbumDto, Album>().ReverseMap();

            //web
            CreateMap<YoutubeVideoWebDto, YoutubeVideo>().ReverseMap();
            CreateMap<CompanyWebDto, Company>().ReverseMap();

            // Para el artist/id de la pagina web
            CreateMap<Artist, ArtistWebDetailDto>();
            CreateMap<Song, SongWebDto>();
            CreateMap<Album, AlbumWebDto>();
            CreateMap<Concert, ConcertWebDto>();

            // Para el generic artist
            CreateMap<Artist, ArtistWebGenericDto>();
            CreateMap<SocialNetwork, SocialNetworkWebDto>();
        
                
            CreateMap<Company, CompanyIntranetDto>().ReverseMap();           
            CreateMap<CompanyType, CompanyTypeIntranetDto>().ReverseMap();


            //intranet
            CreateMap<Artist, ArtistGetDto>()
            .ForMember(dest => dest.socialNetworkIntranetDto, opt => opt.MapFrom(src => src.SocialNetwork))
            .ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkIntranetDto>().ReverseMap();

            
            CreateMap<Song, SongIntranetDto>()
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
            .ReverseMap();

            CreateMap<Album, AlbumIntranetDto>()
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
            .ReverseMap();

            CreateMap<Concert, ConcertIntranetDto>()
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
            .ReverseMap();

            //Filtros 
            CreateMap<Artist, ArtistIntranetNameDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}