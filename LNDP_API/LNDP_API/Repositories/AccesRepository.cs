using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class AccesRepository : GenericRepository<Acces>, IAccesRepository
    {
        private readonly APIContext _context;
        public AccesRepository(APIContext context): base(context)
        {
            _context = context;
        }

        public async Task<bool> UsernameExistAsync(string username){
            return await _context.Acces.AnyAsync(a => a.UserName == username);
        }
        public async Task<Acces> LoginAsync(string username)
        {
            return await _context.Acces
                .AsNoTracking()
                .Include(a => a.User)
                .ThenInclude(u => u.UserRole)
                .FirstOrDefaultAsync(a => a.UserName == username);
        }
    }
}