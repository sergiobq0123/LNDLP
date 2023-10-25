using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class YoutubeVideoRepository : GenericRepository<YoutubeVideo>, IYoutubeVideoRepository
    {
        private readonly APIContext _context;
        public YoutubeVideoRepository(APIContext context): base(context)
        {
            _context = context;
        }
    }
}