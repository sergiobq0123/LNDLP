using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        private readonly APIContext _context;
        public UserRepository(APIContext context): base(context)
        {
            _context = context;
        }
        public async Task<bool> ExistUserMailAsync(string userMail)
        {
            return await _context.User.AnyAsync(v => v.Email == userMail);
        }

        public async Task<bool> ExistUserAsync(int idUser)
        {
            return await _context.User.AnyAsync(v => v.Id == idUser);
        }

    }
}
