using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly APIContext _context;
        public AlbumRepository(APIContext context): base(context)
        {
            _context = context;
        }
    }
}