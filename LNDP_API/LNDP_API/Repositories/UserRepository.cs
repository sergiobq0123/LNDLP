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
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.User
            .Include(u => u.Acces)
            .Include(u => u.UserRole)
            .Select(u => new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserRoleId = u.UserRoleId,
                Acces = new Acces
                {
                    UserName = u.Acces.UserName
                },
                UserRole = new UserRole
                {
                    Id = u.Id,
                    Role = u.UserRole.Role
                }
            })
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
