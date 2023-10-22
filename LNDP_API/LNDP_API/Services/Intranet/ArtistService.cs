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
        private readonly IAccesService _accesService;
        private readonly IUserService _userService;
        private readonly ISocialNetworkService _socialNetworkService;
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        private readonly int userRoleId = 3;
        
        public ArtistService(IArtistRepository artistRepository, IMapper mapper, IImageUtils imageUtils, IAccesService accesService, IUserService userService, ISocialNetworkService socialNetworkService): base(artistRepository, imageUtils)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
            _accesService = accesService;
            _userService = userService;
            _socialNetworkService = socialNetworkService;
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            return await _artistRepository.GetWithIncludesAsync(
                includes: a => a.SocialNetwork
            );
        }
        public async Task<IEnumerable<KeysIntranetDto>> GetArtistKeys()
        {
            var keys =  await _artistRepository.GetAsync();
            return _mapper.Map<IEnumerable<KeysIntranetDto>>(keys);
        }

        public async Task<Artist> PostArtist(ArtistCreateDto artistCreateDto) 
        {
            User newUser = await _userService.PostUser(_mapper.Map<UserCreateDto>(artistCreateDto));

            Artist artist = _mapper.Map<Artist>(artistCreateDto);
            artist.SocialNetwork = _mapper.Map<SocialNetwork>(artistCreateDto);
            artist.UserId = newUser.Id;
            return await this.Create(artist);
        }
        
    }
}
