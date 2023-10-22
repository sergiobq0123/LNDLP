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
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IImageUtils imageUtils) : base(albumRepository, imageUtils)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await _albumRepository.GetWithIncludesAsync(
                includes: a => a.Artist
            );
        }
    }
}
