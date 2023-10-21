using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly IUrlEmbedUtils _urlEmbedUtils;
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        public SongService(IUrlEmbedUtils urlEmbedUtils, ISongRepository songRepository, IMapper mapper) : base(songRepository, null, urlEmbedUtils)
        {
            _urlEmbedUtils = urlEmbedUtils;
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongWebDto>> GetSongDto()
        {
            var songs = await _songRepository.GetAsync();
            return _mapper.Map<IEnumerable<SongWebDto>>(songs);
        }
    }
}
