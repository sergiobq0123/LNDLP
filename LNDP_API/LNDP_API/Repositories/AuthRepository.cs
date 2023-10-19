using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly APIContext _context;
        public AuthRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<Acces> CreateAsync(Acces acces)
        {
            _context.Acces.Add(acces);
            await _context.SaveChangesAsync();
            return acces;
        }

        public async Task<bool> UsernameExistAsync(string username){
            return await _context.Acces.AnyAsync(a => a.UserName == username);
        }
    }
}