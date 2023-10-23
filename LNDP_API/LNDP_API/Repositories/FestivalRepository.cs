using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class FestivalRepository : GenericRepository<Festival>, IFestivalRepository
    {
        private readonly APIContext _context;
        public FestivalRepository(APIContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Festival>> GetFestivalsAsync()
        {
            return await _context.Festival.Include(c => c.ArtistFestivalAsoc).ThenInclude(afa => afa.Artist).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Festival>> GetFestivalsForArtistAsync(int artistId)
        {
            return await _context.Festival
                .Where(f =>
                    f.ArtistFestivalAsoc.Any(afa => afa.ArtistId == artistId)
                )
                .Include(f => f.ArtistFestivalAsoc)
                .ThenInclude(afa => afa.Artist)
                .AsNoTracking()
                .ToListAsync();
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
