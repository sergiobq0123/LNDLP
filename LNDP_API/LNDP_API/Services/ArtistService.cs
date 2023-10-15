using AutoMapper;
using LNDP_API.Controllers;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{

    public class ArtistService : IArtistService{
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IImageService _imageService;

        public ArtistService(IMapper mapper, IAuthService authService, IImageService imageService)
        {
            _mapper = mapper;
            _authService = authService;
                        _imageService = imageService;

        }

        public async Task<Artist> CreateArtist(ArtistCreateDto artistCreateDto)
        {
            var artist = _mapper.Map<Artist>(artistCreateDto);
            var socialNetwork = _mapper.Map<SocialNetwork>(artistCreateDto);
            var userRegistrerDto = _mapper.Map<UserRegistrerDto>(artistCreateDto);
            userRegistrerDto.UserRoleId = 3;
            
            try
            {
                var newUser = await _authService.Register(userRegistrerDto);
                artist.PhotoUrl = await _imageService.ConvertBase64ToUrl(artistCreateDto.PhotoUrl, artistCreateDto.Name);
                artist.SocialNetwork = socialNetwork;
                artist.User = newUser;
                return artist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
