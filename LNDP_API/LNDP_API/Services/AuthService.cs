using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;
using TTTAPI.JWT.Models;
using System.Security.Claims;
using TTTAPI.JWT.Managers;
using LNDP_API.Utils;
using LNDP_API.Repositories;

namespace LNDP_API.Services{

    public class AuthService : IAuthService{
        private readonly APIContext _context;
        private readonly IMapper _mapper; 
        private readonly IJwtService _jwtService; 
        private readonly string _pepper = "pepper";
        private readonly int _iteration = 3;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        public AuthService(APIContext context, IMapper mapper, IJwtService jwtService, IAuthRepository authRepository, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<Acces> Register(AccesDto accesDto)
        {
            
            Acces acces = _mapper.Map<Acces>(accesDto);
            acces.PasswordSalt = PasswordHasher.GenerateSalt();
            acces.PasswordHash = PasswordHasher.ComputeHash(accesDto.Password, acces.PasswordSalt, _pepper, _iteration);
            return await _authRepository.CreateAsync(acces);
        }

        public async Task<bool> ExistUserName(string username)
        {
            return await _authRepository.UsernameExistAsync(username);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.User
                .Include(user => user.UserRole)
                .FirstOrDefaultAsync(x => x.Email == email);
            if(user == null){
                throw new Exception("Usuario no registrado");
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

        public async Task<User> UpdateUser(UserIntranetDto userRegistrerDto)
        {
            User newUser = _mapper.Map<User>(userRegistrerDto);

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
    }
}
