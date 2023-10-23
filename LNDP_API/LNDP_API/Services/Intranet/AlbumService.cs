using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class AlbumService : GenericService<Album>, IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper) : base(albumRepository, mapper)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _albumRepository.GetWithIncludesAsync(
                includes: a => a.Artist
            );
        }
    }
}
