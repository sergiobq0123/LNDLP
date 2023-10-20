using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IArtistRepository{
        Task<IEnumerable<Artist>> GetAsync();
        Task<bool> ExistArtistAsync(int idArtist);
        Task<Artist> CreateAsync(Artist artist);
        Task<Artist> UpdateAsync(Artist artist);
        Task DeleteAsync(int idArtist);
    }
}