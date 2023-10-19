using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly APIContext _context;
        public ConcertRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Concert>> GetAsync()
        {
            return await _context.Concert.Include(c => c.Artist).ToListAsync();
        }
        public async Task<IEnumerable<Concert>> GetConcertsArtistAsync(int idArtista)
        {
            DateTime fechaActualUtc = DateTime.UtcNow;
            return await _context.Concert.Include(c => c.Artist).Where(c => c.ArtistId == idArtista && c.Date >= fechaActualUtc).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Concert>> GetFutureConcertsAsync()
        {
            DateTime fechaActualUtc = DateTime.UtcNow;
            return await _context.Concert.Include(c => c.Artist).Where(c => c.Date >= fechaActualUtc).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistConcertAsync(int idConcert)
        {
            return await _context.Concert.AsNoTracking().AnyAsync(c => c.Id == idConcert);
        }

        public async Task<Concert> CreateAsync(Concert concert)
        {
            _context.Concert.Add(concert);
            await _context.SaveChangesAsync();
            return concert;
        }

        public async Task<Concert> UpdateAsync(Concert concert)
        {
            _context.Concert.Update(concert);
            await _context.SaveChangesAsync();
            return concert;
        }

        public async Task DeleteAsync(int idConcert)
        {
            _context.Concert.Remove(await _context.Concert.FindAsync(idConcert));
            await _context.SaveChangesAsync();
        }
    }
}
