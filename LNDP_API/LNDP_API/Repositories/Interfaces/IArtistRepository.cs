using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<IQueryable<Artist>> GetArtistasAsync();
        Task<Artist> GetArtistByIdAsync(int id);
    }
}