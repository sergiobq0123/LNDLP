using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<IQueryable<Artist>> GetArtistasAsync(Expression<Func<Artist, bool>> predicate);
        Task<Artist> GetArtistByIdAsync(int id);
        Task<IEnumerable<Artist>> GetArtistWithSocialNetwork();
    }
}