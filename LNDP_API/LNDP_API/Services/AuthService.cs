using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;
using TTTAPI.JWT.Models;
using System.Security.Claims;
using TTTAPI.JWT.Managers;

namespace LNDP_API.Services{

    public class AuthService : IAuthService{
        private readonly APIContext _context;
        private readonly IMapper _mapper; 
        private readonly IJwtService _jwtService; 
        public AuthService(APIContext context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<User> Register(UserRegistrerDto userDto) 
        {
            bool userExists = await ExistUser(userDto.Email);

            if (userExists)
            {
                throw new Exception("User with this email is registered");
            }

            var userNew = _mapper.Map<User>(userDto);
            var user = await RegisterPassword(userNew, userDto.Password);
            return user;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.User
                .Include(user => user.UserRole)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Password is incorrect");
            }
            IJwtContainer model = new JwtContainer()
            {
                Claims = new Claim[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("role", user.UserRole.Role.ToString())
                }
            };
            string token = _jwtService.GenerateToken(model);
            return token;
        }

        private async Task<User> RegisterPassword(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
            
        }

        private async Task<bool> ExistUser(string email)
        {
            return await _context.User.AnyAsync( x=> x.Email == email);
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
