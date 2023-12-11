using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Utils;

namespace LNDP_API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //! Iniciar sesión
            CreateMap<AccesDto, Acces>().ReverseMap();

            //! Intranet
            //* Artista
            CreateMap<ArtistCreateDto, SocialNetwork>();
            CreateMap<ArtistCreateDto, Artist>();
            CreateMap<Artist, ArtistCreateDto>().ReverseMap();
            CreateMap<UserCreateDto, ArtistCreateDto>().ReverseMap();
            CreateMap<SocialNetwork, ArtistCreateDto>().ReverseMap();

            //* POST de User
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<AccesDto, UserCreateDto>().ReverseMap();

            //* Para los dropdown 
            CreateMap<Artist, KeysIntranetDto>();
            CreateMap<CompanyType, KeysIntranetDto>()
                .ForMember(u => u.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<UserRole, KeysIntranetDto>()
                .ForMember(u => u.Name, opt => opt.MapFrom(src => src.Role));

            //! WEB
            CreateMap<YoutubeVideoWebDto, YoutubeVideo>().ReverseMap();
            CreateMap<CompanyWebDto, Company>().ReverseMap();

            //* Para el artist/id de la pagina web
            CreateMap<ArtistWebDetailDto, Artist>().ReverseMap();
            CreateMap<Song, SongWebDto>();
            CreateMap<Album, AlbumWebDto>();
            CreateMap<Concert, ConcertWebDto>()
                .ForMember(u => u.PhotoUrl, opt => opt.MapFrom(src => src.Artist.PhotoUrl));
            CreateMap<Festival, FestivalWebDto>();

            //* Para el generic artist
            CreateMap<Artist, ArtistWebGenericDto>();
            CreateMap<SocialNetwork, SocialNetworkWebDto>();

        }
    }
}