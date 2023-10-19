using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface ISongRepository{
        Task<IEnumerable<Song>> GetAsync();
        Task<bool> ExistSongAsync(int idSong);
        Task<Song> CreateAsync(Song song);
        Task<Song> UpdateAsync(Song song);
        Task DeleteAsync(int idSong);
    }
}