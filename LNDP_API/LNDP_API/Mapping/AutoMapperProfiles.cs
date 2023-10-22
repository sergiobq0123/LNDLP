using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Utils;

namespace LNDP_API.Mapping{
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles()
        {
            // Inicio de sesión
            CreateMap<UserLoginDto, User>();
            CreateMap<AccesDto, Acces>().ReverseMap();

            // postArtist
            CreateMap<ArtistCreateDto, SocialNetwork>();
            CreateMap<ArtistCreateDto, Artist>();
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
            CreateMap<Artist, KeysIntranetDto>().ReverseMap();

            CreateMap<Artist, ArtistGetDto>()
            .ForMember(dest => dest.socialNetworkIntranetDto, opt => opt.MapFrom(src => src.SocialNetwork))
            .ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkIntranetDto>().ReverseMap();

            //Filtros 
            CreateMap<Artist, ArtistIntranetNameDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();

            //! POST de Artista
            CreateMap<Artist, ArtistCreateDto>().ReverseMap();
            CreateMap<UserCreateDto, ArtistCreateDto>().ReverseMap();
            CreateMap<SocialNetwork, ArtistCreateDto>().ReverseMap();

            //! POST de User
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<AccesDto, UserCreateDto>().ReverseMap();

        }
    }
}