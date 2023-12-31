using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public class FestivalRepository : GenericRepository<Festival>, IFestivalRepository
    {
        private readonly APIContext _context;
        public FestivalRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Festival>> GetFestivalesAsync(Expression<Func<Festival, bool>> predicate)
        {
            var query = _context.Festival.Include(c => c.ArtistFestivalAsoc).ThenInclude(afa => afa.Artist).AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }

        public async Task<IEnumerable<Festival>> GetFutureFestivalsAsync()
        {
            return await _context.Festival
                .Where(c => c.Date >= DateTime.UtcNow).OrderBy(c => c.Date)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
