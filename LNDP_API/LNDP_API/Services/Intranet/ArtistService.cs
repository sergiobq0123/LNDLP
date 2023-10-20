using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public ArtistService(IArtistRepository artistRepository, IMapper mapper, IImageUtils imageUtils)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<Artist>> GetArtist()
        {
            return await _artistRepository.GetAsync();
        }
        public async Task<IEnumerable<KeysIntranetDto>> GetArtistKeys()
        {
            var keys =  await _artistRepository.GetAsync();
            return _mapper.Map<IEnumerable<KeysIntranetDto>>(keys);
        }

        public async Task<Artist> CreateArtist(Artist artist)
        {
            artist.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(artist.PhotoUrl, artist.Name);
            return await _artistRepository.CreateAsync(artist);
        }
        
        public async Task<bool> ExistArtist(int idArtist)
        {
            return await _artistRepository.ExistArtistAsync(idArtist);
        }

        public async Task<Artist> UpdateArtist(Artist artist)
        {
            if(!_imageUtils.IsValidUrl(artist.PhotoUrl)){
                artist.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(artist.PhotoUrl, artist.Name);
            }
            return await _artistRepository.UpdateAsync(artist);
        }

        public async Task DeleteArtist(int idArtist)
        {
            await _artistRepository.DeleteAsync(idArtist);
        }
        

    }
}
