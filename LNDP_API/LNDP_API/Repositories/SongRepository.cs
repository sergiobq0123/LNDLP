using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly APIContext _context;
        public SongRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Song>> GetAsync()
        {
            return await _context.Song.Include(s => s.Artist).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistSongAsync(int idSong)
        {
            return await _context.Song.AnyAsync(v => v.Id == idSong);
        }

        public async Task<Song> CreateAsync(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }
        public async Task<Song> UpdateAsync(Song song)
        {
            _context.Song.Update(song);
            await _context.SaveChangesAsync();
            return song;
        }
        public async Task DeleteAsync(int idSong)
        {
            _context.Song.Remove(await _context.Song.FindAsync(idSong));
            await _context.SaveChangesAsync();
        }
    }
}
