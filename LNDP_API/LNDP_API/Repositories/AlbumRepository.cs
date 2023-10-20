using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly APIContext _context;
        public AlbumRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Album>> GetAsync()
        {
            return await _context.Album.Include(a => a.Artist).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistAlbumAsync(int idAlbum)
        {
            return await _context.Album.AnyAsync(v => v.Id == idAlbum);
        }

        public async Task<Album> CreateAsync(Album album)
        {
            _context.Album.Add(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> UpdateAsync(Album album)
        {
            _context.Album.Update(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task DeleteAsync(int idAlbum)
        {
            _context.Album.Remove(await _context.Album.FindAsync(idAlbum));
            await _context.SaveChangesAsync();
        }
    }
}
