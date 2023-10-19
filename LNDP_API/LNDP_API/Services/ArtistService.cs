using AutoMapper;
using LNDP_API.Controllers;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{

    public class ArtistService : IArtistService{
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public ArtistService(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;

        }

        public async Task<Artist> CreateArtist(ArtistCreateDto artistCreateDto)
        {
            var artist = _mapper.Map<Artist>(artistCreateDto);
            var socialNetwork = _mapper.Map<SocialNetwork>(artistCreateDto);
            var userRegistrerDto = _mapper.Map<UserIntranetDto>(artistCreateDto);
            userRegistrerDto.UserRoleId = 3;
            
            try
            {
                //var newUser = await _authService.Register(userRegistrerDto);
                artist.SocialNetwork = socialNetwork;
                //artist.User = newUser;
                return artist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
