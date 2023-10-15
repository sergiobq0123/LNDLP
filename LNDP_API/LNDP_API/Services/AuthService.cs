using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;
using TTTAPI.JWT.Models;
using System.Security.Claims;
using TTTAPI.JWT.Managers;
using LNDP_API.Utils.PasswordHasher;

namespace LNDP_API.Services{

    public class AuthService : IAuthService{
        private readonly APIContext _context;
        private readonly IMapper _mapper; 
        private readonly IJwtService _jwtService; 
        private readonly string _pepper = "pepper";
        private readonly int _iteration = 3;
        public AuthService(APIContext context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<User> Register(UserRegistrerDto userDto)
        {
            if (await ExistUserEmail(userDto.Email))
            {
                throw new Exception("El usuario con este correo ya existe");
            }
            if (await ExistUserUsername(userDto.Username))
            {
                throw new Exception("El usuario con este nombre ya existe");
            }
            var userNew = _mapper.Map<User>(userDto);
            userNew.UserRole = _context.UserRole.Find(userDto.UserRoleId);
            userNew.PasswordSalt = PasswordHasher.GenerateSalt();
            userNew.PasswordHash = PasswordHasher.ComputeHash(userDto.Password, userNew.PasswordSalt, _pepper, _iteration);
            await _context.User.AddAsync(userNew);
            await _context.SaveChangesAsync();
            return userNew;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.User
                .Include(user => user.UserRole)
                .FirstOrDefaultAsync(x => x.Email == email);
            if(user == null){
                throw new Exception("Usuario no registrado");
            }
            var passwordHash = PasswordHasher.ComputeHash(password, user.PasswordSalt, _pepper, _iteration);
            if(user.PasswordHash != passwordHash){
                throw new Exception("La contraseña es incorrecta");
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

        public async Task<User> UpdateUser(UserRegistrerDto userRegistrerDto)
        {
            User newUser = _mapper.Map<User>(userRegistrerDto);
            if (userRegistrerDto.Password == null){
                User user = await _context.User.AsNoTracking().FirstAsync(u => u.Id == userRegistrerDto.Id);
                newUser.PasswordHash = user.PasswordHash;
                newUser.PasswordSalt = user.PasswordSalt;
            }else{
                newUser.PasswordSalt = PasswordHasher.GenerateSalt();
                newUser.PasswordHash = PasswordHasher.ComputeHash(userRegistrerDto.Password, newUser.PasswordSalt, _pepper, _iteration);
            }
            return newUser;
        }
        
        public async Task DeleteUser(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            var artist = await _context.Artist
                .Include(a => a.User) 
                .FirstOrDefaultAsync(a => a.User.Id == user.Id);
            if (artist != null){
                _context.Artist.Remove(artist);
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> ExistUserEmail(string email)
        {
            return await _context.User.AnyAsync( x=> x.Email == email);
        }
        private async Task<bool> ExistUserUsername(string username)
        {
            return await _context.User.AnyAsync( x=> x.Username == username);
        }
        
    }
}
