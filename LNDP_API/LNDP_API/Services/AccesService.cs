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
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using LNDP_API.Filters;


namespace LNDP_API.Services
{
    public class AccesService : GenericService<Acces>, IAccesService
    {
        private readonly IAccesRepository _accesRepository;
        private readonly IJwtService _jwtService;
        private readonly string _pepper = "pepper";
        private readonly int _iteration = 3;
        public AccesService(IAccesRepository accesRepository, IJwtService jwtService, IMapper mapper, IUriService uriService) : base(accesRepository, mapper, uriService)
        {
            _accesRepository = accesRepository;
            _jwtService = jwtService;
        }

        public async Task<Acces> Register(AccesDto accesDto)
        {
            await UsernameExist(accesDto.Username);
            Acces acces = _mapper.Map<Acces>(accesDto);
            acces.PasswordSalt = PasswordHasher.GenerateSalt();
            acces.PasswordHash = PasswordHasher.ComputeHash(accesDto.Password, acces.PasswordSalt, _pepper, _iteration);
            return await _accesRepository.CreateAsync(acces);
        }

        public async Task<string> Login(AccesDto accesDto)
        {
            Acces acces = await _accesRepository.LoginAsync(accesDto.Username) ?? throw new Exception("Usuario no registrado");
            string inputPasswordHash = PasswordHasher.ComputeHash(accesDto.Password, acces.PasswordSalt, _pepper, _iteration);
            if (inputPasswordHash != acces.PasswordHash)
            {
                throw new Exception("Contraseña incorrecta");
            }
            IJwtContainer model = new JwtContainer()
            {
                Claims = new Claim[]
                {
                    new Claim("userId", acces.User.Id.ToString()),
                    new Claim("role", acces.User.UserRole.Role.ToString())
                }
            };

            return _jwtService.GenerateToken(model);
        }

        private async Task UsernameExist(string username)
        {
            bool exists = await _accesRepository.UsernameExistAsync(username);
            if (exists)
            {
                throw new Exception($"El usuario '{username}' ya está registrado");
            }
        }

        public async Task ChangePassword(int id, string password)
        {
            Acces acces = await _accesRepository.GetByIdAsync(id);
            acces.PasswordSalt = PasswordHasher.GenerateSalt();
            acces.PasswordHash = PasswordHasher.ComputeHash(password, acces.PasswordSalt, _pepper, _iteration);
            await _accesRepository.SaveChangesAsync();
        }
    }
}
