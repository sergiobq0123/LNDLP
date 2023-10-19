using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class FestivalRepository : IFestivalRepository
    {
        private readonly APIContext _context;
        public FestivalRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Festival>> GetAsync()
        {
            return await _context.Festival.Include(c => c.ArtistFestivalAsoc).ThenInclude(afa => afa.Artist).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistFestivalAsync(int idFestival)
        {
            return await _context.Festival.AnyAsync(v => v.Id == idFestival);
        }

        public async Task<Festival> CreateAsync(Festival festival)
        {
            _context.Festival.Add(festival);
            await _context.SaveChangesAsync();
            return festival;
        }

        public async Task<Festival> UpdateAsync(Festival festival)
        {
            _context.Festival.Update(festival);
            await _context.SaveChangesAsync();
            return festival;
        }

        public async Task DeleteAsync(int idFestival)
        {
            _context.Festival.Remove(await _context.Festival.FindAsync(idFestival));
            await _context.SaveChangesAsync();
        }
    }
}
