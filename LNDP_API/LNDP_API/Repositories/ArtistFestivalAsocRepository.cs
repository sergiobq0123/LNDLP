using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ArtistFestivalAsocRepository : IArtistFestivalAsocRepository
    {
        private readonly APIContext _context;
        public ArtistFestivalAsocRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ArtistFestivalAsoc>> GetAsync()
        {
            return await _context.ArtistFestivalAsoc.Include(a => a.Artist).AsNoTracking().ToListAsync();
        }
        public async Task<int> GetIdByArtistFestival(int idArtista, int idfestival)
        {
            ArtistFestivalAsoc artistFestivalAsoc = await  _context.ArtistFestivalAsoc.AsNoTracking().FirstOrDefaultAsync(a => a.ArtistId == idArtista && a.FestivalId == idfestival);
            return artistFestivalAsoc.Id;
        }
        
        public async Task<bool> ExistArtistFestivalAsocAsync(int idArtistFestivalAsoc)
        {
            return await _context.ArtistFestivalAsoc.AnyAsync(v => v.Id == idArtistFestivalAsoc);
        }

        public async Task<ArtistFestivalAsoc> CreateAsync(ArtistFestivalAsoc artistFestivalAsoc)
        {
            _context.ArtistFestivalAsoc.Add(artistFestivalAsoc);
            await _context.SaveChangesAsync();
            return artistFestivalAsoc;
        }

        public async Task<ArtistFestivalAsoc> UpdateAsync(ArtistFestivalAsoc artistFestivalAsoc)
        {
            _context.ArtistFestivalAsoc.Update(artistFestivalAsoc);
            await _context.SaveChangesAsync();
            return artistFestivalAsoc;
        }

        public async Task DeleteAsync(int idArtistFestivalAsoc)
        {
            _context.ArtistFestivalAsoc.Remove(await _context.ArtistFestivalAsoc.FindAsync(idArtistFestivalAsoc));
            await _context.SaveChangesAsync();
        }
    }
}
