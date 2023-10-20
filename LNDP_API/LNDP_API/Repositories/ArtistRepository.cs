using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly APIContext _context;
        public ArtistRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Artist>> GetAsync()
        {
            return await _context.Artist.Include(a => a.SocialNetwork).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistArtistAsync(int idArtist)
        {
            return await _context.Artist.AnyAsync(v => v.Id == idArtist);
        }

        public async Task<Artist> CreateAsync(Artist artist)
        {
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task<Artist> UpdateAsync(Artist artist)
        {
            _context.Artist.Update(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task DeleteAsync(int idArtist)
        {
            _context.Artist.Remove(await _context.Artist.FindAsync(idArtist));
            await _context.SaveChangesAsync();
        }
    }
}
