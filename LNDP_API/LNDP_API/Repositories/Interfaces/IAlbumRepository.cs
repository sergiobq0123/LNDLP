using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IAlbumRepository{
        Task<IEnumerable<Album>> GetAsync();
        Task<bool> ExistAlbumAsync(int idAlbum);
        Task<Album> CreateAsync(Album album);
        Task<Album> UpdateAsync(Album album);
        Task DeleteAsync(int idAlbum);
    }
}