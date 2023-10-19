using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetSong();
        Task<IEnumerable<SongWebDto>> GetSongDto();
        Task<bool> ExistSong(int idSong);
        Task<Song> CreateSong(Song song);
        Task<Song> UpdateSong(Song song);
        Task DeleteSong(int idSong);
    }
}