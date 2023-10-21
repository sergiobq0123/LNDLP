using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class ArtistRepository :GenericRepository<Artist>, IArtistRepository
    {
        private readonly APIContext _context;
        public ArtistRepository(APIContext context) : base(context)
        {
            _context = context;
        }
    }
}
