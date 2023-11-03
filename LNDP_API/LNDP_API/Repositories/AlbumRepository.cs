using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly APIContext _context;
        public AlbumRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Album>> GetAlbumsAsync(Expression<Func<Album, bool>> predicate)
        {
            var query = _context.Album.Include(c => c.Artist).AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }
    }
}