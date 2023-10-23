using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class ArtistService : GenericService<Artist>, IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IUserService _userService;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper, IUserService userService) : base(artistRepository, mapper)
        {
            _artistRepository = artistRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            return await _artistRepository.GetWithIncludesAsync(
                includes: a => a.SocialNetwork
            );
        }
        public async Task<ArtistWebDetailDto> GetArtistById(int id)
        {
            Artist artist = await _artistRepository.GetArtistByIdAsync(id);
            return _mapper.Map<ArtistWebDetailDto>(artist);
        }

        public async Task<Artist> PostArtist(ArtistCreateDto artistCreateDto)
        {
            User newUser = await _userService.PostUser(_mapper.Map<UserCreateDto>(artistCreateDto));
            Artist artist = _mapper.Map<Artist>(artistCreateDto);
            artist.SocialNetwork = _mapper.Map<SocialNetwork>(artistCreateDto);
            artist.UserId = newUser.Id;
            return await Create(artist);
        }

        public async Task<IEnumerable<ArtistWebGenericDto>> GetArtistsWeb()
        {
            var artistas = await _artistRepository.GetWithIncludesAsync(
                includes: a => a.SocialNetwork
            );
            return _mapper.Map<IEnumerable<ArtistWebGenericDto>>(artistas);
        }
    }
}
