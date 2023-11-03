using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        private readonly APIContext _context;
        public ArtistRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Artist>> GetArtistasAsync(Expression<Func<Artist, bool>> predicate)
        {
            var query = _context.Artist.Include(c => c.SocialNetwork).AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await Task.FromResult(query);
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artist = await _context.Artist
                .Include(a => a.Songs)
                .Include(a => a.Albums)
                .Include(a => a.Concerts)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            artist.Concerts = artist.Concerts.Where(c => c.Date >= DateTime.UtcNow).OrderBy(c => c.Date).ToList();
            return artist;
        }
        public async Task<IEnumerable<Artist>> GetArtistWithSocialNetwork()
        {
            return await _context.Artist
                .Include(a => a.SocialNetwork)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
