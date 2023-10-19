using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIContext _context;
        public UserRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.User.Include(u => u.UserRole).ToListAsync();
        }

        public async Task<bool> ExistUserMailAsync(string userMail)
        {
            return await _context.User.AnyAsync(v => v.Email == userMail);
        }

        public async Task<bool> ExistUserAsync(int idUser)
        {
            return await _context.User.AnyAsync(v => v.Id == idUser);
        }

        public async Task<User> CreateAsync(User User)
        {
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User> UpdateAsync(User User)
        {
            _context.User.Update(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task DeleteAsync(int idUser)
        {
            _context.User.Remove(await _context.User.FindAsync(idUser));
            await _context.SaveChangesAsync();
        }
    }
}
