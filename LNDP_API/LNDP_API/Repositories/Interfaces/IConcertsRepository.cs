using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IConcertRepository : IGenericRepository<Concert>
    {
        Task<IQueryable<Concert>> GetConcertsAsync();
        Task<IQueryable<Concert>> GetConcertsForArtistAsync(int id);
        Task<IEnumerable<Concert>> GetFutureConcertsAsync();
    }
}