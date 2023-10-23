using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ArtistFestivalAsocRepository : GenericRepository<ArtistFestivalAsoc>, IArtistFestivalAsocRepository
    {
        private readonly APIContext _context;
        public ArtistFestivalAsocRepository(APIContext context) : base(context)
        {
            _context = context;
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
        public async Task<IEnumerable<ArtistFestivalAsoc>> GetFestivalsForArtistAsync(int id)
        {
            return await _context.ArtistFestivalAsoc
                .Include(a => a.Artist)
                .Include(a => a.Festival)
                .Where( a => a.Artist.UserId == id)
                .ToListAsync();
        }
    }
}
