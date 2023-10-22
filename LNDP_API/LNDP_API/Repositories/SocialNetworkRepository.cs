using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class SocialNetworkRepository : GenericRepository<SocialNetwork>, ISocialNetworkRepository
    {
        private readonly APIContext _context;
        public SocialNetworkRepository(APIContext context) : base(context)
        {
            _context = context;
        }

    }
}
