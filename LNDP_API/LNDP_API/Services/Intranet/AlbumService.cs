using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IImageUtils imageUtils)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<Album>> GetAlbum()
        {
            return await _albumRepository.GetAsync();
        }

        public async Task<Album> CreateAlbum(Album album)
        {
            album.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(album.PhotoUrl, album.Name);
            return await _albumRepository.CreateAsync(album);
        }
        
        public async Task<bool> ExistAlbum(int idAlbum)
        {
            return await _albumRepository.ExistAlbumAsync(idAlbum);
        }

        public async Task<Album> UpdateAlbum(Album album)
        {
            if(!_imageUtils.IsValidUrl(album.PhotoUrl)){
                album.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(album.PhotoUrl, album.Name);
            }
            return await _albumRepository.UpdateAsync(album);
        }

        public async Task DeleteAlbum(int idAlbum)
        {
            await _albumRepository.DeleteAsync(idAlbum);
        }
        

    }
}
