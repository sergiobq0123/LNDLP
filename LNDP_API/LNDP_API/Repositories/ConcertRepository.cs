using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public class ConcertRepository : GenericRepository<Concert>, IConcertRepository
    {
        private readonly APIContext _context;
        public ConcertRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Concert>> GetConcertsAsync(Expression<Func<Concert, bool>> predicate)
        {
            var query = _context.Concert.Include(c => c.Artist).AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }

        public async Task<IEnumerable<Concert>> GetFutureConcertsAsync()
        {
            return await _context.Concert
                .Include(c => c.Artist)
                .Where(c => c.Date >= DateTime.UtcNow)
                .OrderBy(c => c.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IQueryable<Concert>> GetConcertsForArtistAsync(Expression<Func<Concert, bool>> predicate, int id)
        {
            var query = _context.Concert
                .Include(a => a.Artist)
                .Where(a => a.Artist.UserId == id)
                .AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }
    }
}
