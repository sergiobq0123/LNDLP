using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository, IMapper mapper) : base(songRepository, mapper)
        {
            _songRepository = songRepository;
        }

        public async Task<IEnumerable<Song>> GetSongs()
        {
            return await _songRepository.GetWithIncludesAsync(
                includes: s => s.Artist
            );
        }
    }
}
