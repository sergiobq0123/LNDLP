using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ConcertRepository : GenericRepository<Concert>, IConcertRepository
    {
        private readonly APIContext _context;
        public ConcertRepository(APIContext context) : base(context)
        {
            _context = context;
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
    }
}
