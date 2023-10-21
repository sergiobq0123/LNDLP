using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class SongRepository :GenericRepository<Song>, ISongRepository
    {
        private readonly APIContext _context;
        public SongRepository(APIContext context): base(context)
        {
            _context = context;
        }
    }
}
