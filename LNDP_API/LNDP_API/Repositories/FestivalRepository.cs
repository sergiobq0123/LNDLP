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
        public async Task<IEnumerable<Festival>> GetWithRelationAsync()
        {
            return await _context.Festival.Include(c => c.ArtistFestivalAsoc).ThenInclude(afa => afa.Artist).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistFestivalAsync(int idFestival)
        {
            return await _context.Festival.AnyAsync(v => v.Id == idFestival);
        }
    }
}
