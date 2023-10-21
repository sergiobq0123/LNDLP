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
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public ArtistService(IArtistRepository artistRepository, IMapper mapper, IImageUtils imageUtils): base(artistRepository)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }
        public async Task<IEnumerable<KeysIntranetDto>> GetArtistKeys()
        {
            var keys =  await _artistRepository.GetAsync();
            return _mapper.Map<IEnumerable<KeysIntranetDto>>(keys);
        }
    }
}
