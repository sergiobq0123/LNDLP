using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class SongService : ISongService
    {
        private readonly IUrlEmbedUtils _urlEmbedUtils;
        private readonly ISongRepository _SongRepository;
        private readonly IMapper _mapper;
        public SongService(IUrlEmbedUtils urlEmbedUtils, ISongRepository SongRepository, IMapper mapper)
        {
            _urlEmbedUtils = urlEmbedUtils;
            _SongRepository = SongRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Song>> GetSong()
        {
            return await _SongRepository.GetAsync();
        }

        public async Task<IEnumerable<SongWebDto>> GetSongDto()
        {
            var songs = await _SongRepository.GetAsync();
            return _mapper.Map<IEnumerable<SongWebDto>>(songs);
        }

        public async Task<Song> CreateSong(Song song)
        {
            song.Url = _urlEmbedUtils.GetEmbedUrlYoutube(song.Url);
            return await _SongRepository.CreateAsync(song);
        }
        
        public async Task<bool> ExistSong(int idSong)
        {
            return await _SongRepository.ExistSongAsync(idSong);
        }

        public async Task<Song> UpdateSong(Song song)
        {
            song.Url = _urlEmbedUtils.GetEmbedUrlYoutube(song.Url);
            return await _SongRepository.UpdateAsync(song);
        }

        public async Task DeleteSong(int idSong)
        {
            await _SongRepository.DeleteAsync(idSong);
        }
    }
}
