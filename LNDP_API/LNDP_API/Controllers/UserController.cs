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
    public class UserController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController(APIContext context, IAuthService authService, IUserService userService)
        {
            _context = context;
            _authService = authService;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserIntranetDto>>> GetUsers()
        {
            try{
                return Ok(await _userService.GetUser());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {         
            var user = await _context.User.Include(u => u.UserRole).FirstOrDefaultAsync(u => u.Id == id);
    
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) 
        {
            try
            {
                User u = await _userService.CreateUser(user);
                return Ok(new { Message = "Usuario creado con éxito", u });
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, User user)
        {
            if (!await _userService.ExistUser(id))
            {
                return BadRequest(new { Message = "El usuario especificado no exise."});
            }
            try{
                User u = await _userService.UpdateUser(user);
                return Ok(new { Message = "Usuario actualizado con éxito.", u});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try{
                await _authService.DeleteUser(id);
                return Ok(new { Message = "Usuario borrado con éxito" });
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}
