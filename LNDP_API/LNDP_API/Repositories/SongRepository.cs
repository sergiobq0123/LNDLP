using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly APIContext _context;
        public SongRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Song>> GetSongsAsync(Expression<Func<Song, bool>> predicate)
        {
            var query = _context.Song.Include(c => c.Artist).AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }
    }
}
