using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using LNDP_API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User>
    {
        private readonly APIContext _context;
        private readonly IUserService _userService;

        public UserController(APIContext context, IUserService userService): base(userService)
        {
            _context = context;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try{
                return Ok(await _userService.GetUsers());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-register")]
        public async Task<ActionResult<IEnumerable<User>>> PostUser(UserCreateDto userCreateDto)
        {
            try{
                await _userService.PostUser(userCreateDto);
                return Ok(new { Message = "Usuario creado(a) con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}
