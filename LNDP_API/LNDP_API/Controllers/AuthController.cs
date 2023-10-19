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
                return BadRequest(new { ex.Message});
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(AccesDto accesDto)
        {
            if(await _authService.ExistUserName(accesDto.Username)){
                return BadRequest(new { Message = "El usuario con este username ya existe" });
            }
            try
            {
                await _authService.Register(accesDto);
                return Ok(new { Message = "Usuario registrado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}