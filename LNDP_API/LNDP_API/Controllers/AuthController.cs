using AutoMapper;
using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LNDP_API.Controllers{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase{
        private readonly IAuthService _authService;
        private readonly APIContext _context;


        public AuthController(IAuthService authService,  APIContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegistrerDto userDto) 
        {
            try
            {
                var user = await _authService.Register(userDto);
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto)
        {
            try
            {
                string token = await _authService.Login(userLoginDto.Email, userLoginDto.Password);
                return Ok(new {token});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}