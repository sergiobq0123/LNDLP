using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IArtistRepository : IGenericRepository<Artist>{
        Task<Artist> GetArtistByIdAsync(int id);
    }
}