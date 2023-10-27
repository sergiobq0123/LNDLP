using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<IQueryable<Song>> GetSongsAsync(Expression<Func<Song, bool>> predicate);
    }
}