using AutoMapper;
using LNDP_API.Controllers;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{

    public class ArtistService : IArtistService{
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public ArtistService(APIContext context, IMapper mapper, IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<Artist> CreateArtist(ArtistDto artistDto){
            var artist = _mapper.Map<Artist>(artistDto);
            var socialNetwork = _mapper.Map<SocialNetwork>(artistDto);
            var crew = _mapper.Map<Crew>(artistDto);
            var user = _mapper.Map<UserRegistrerDto>(artistDto);
            var newUser = await _authService.Register(user);
            artist.SocialNetwork = socialNetwork;
            artist.Crew = crew;
            artist.User = newUser;
            return artist;
        }
    }
}
