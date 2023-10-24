using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly APIContext _context;
        public AlbumRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Album>> GetAlbumsAsync()
        {
            var query = _context.Album.Include(c => c.Artist).AsNoTracking();
            return await Task.FromResult(query);
        }
    }
}