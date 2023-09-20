using LNDP_API.Data.Interfaces;
using LNDP_API.Models;
using LNDP_API.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Data {
    public class AuthRepository : IAuthRepository
    {
        private readonly APIContext _context;

        public AuthRepository(APIContext context){
            this._context = context;
        }
        public async Task<bool> ExistUser(string email)
        {
            return await _context.User.AnyAsync( x=> x.Email == email);
        }

        public async Task<User> Login(string email, string password)
        {

            var user = await _context.User.Include(user => user.UserRole).FirstOrDefaultAsync(x => x.Email == email);
            if(user == null){
                return null;
            }
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)){
                return null;
            }

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}