using System.Data.Entity;
using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Data.Interfaces;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Controllers{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase{
        private readonly IAuthRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repository, ITokenService tokenService, APIContext context, IMapper mapper)
        {
            _repository = repository;
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(UserRegistrerDto userDto) {

        userDto.Email = userDto.Email.ToLower();
        if(await _repository.ExistUser(userDto.Email)){
            return BadRequest("User with this email is registered");
        }
        var userNew = _mapper.Map<User>(userDto);
        var userCreated = await _repository.Register(userNew, userDto.Password);
        var userReturn = _mapper.Map<UserLisDto>(userCreated); 
        return Ok(userReturn);
     }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto){

        if(!await _repository.ExistUser(userLoginDto.Email)){
            return BadRequest("User not found");
        }else {
            var userFrom = await _repository.Login(userLoginDto.Email, userLoginDto.Password);
            if(userFrom == null ){
                return BadRequest("Password is incorrect");
            }else{
               // var user = _mapper.Map<UserLisDto>(userFrom);
                var token = _tokenService.CreateToken(userFrom);
                return Ok(new { userFrom, token});
            }
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

 }
}