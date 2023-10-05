using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using LNDP_API.Services;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IAuthService _authService;

        public UserController(APIContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if(_context.User == null){
                return NotFound();
            }
            return await _context.User
            .Include(u => u.UserRole)
            .Where(u => u.UserRoleId == 1)
            .ToListAsync();

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
        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<User>>> GetFilteredUser([FromBody] List<Filter> filters)
        {
            if (_context.User == null)
            {
                return NotFound();
            }

            Expression<Func<User, bool>> predicate = FilterUtils.GetPredicate<User>(filters);
            return await _context.User.Where(predicate).ToListAsync();
        }

        // Use Auth
        [HttpPost]
        public async Task<ActionResult<User>> Register(UserRegistrerDto userDto) 
        {
            try
            {
                var user = await _authService.Register(userDto);
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Usuario creado con éxito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            if(_context.User == null){
                return NotFound();
            }
            var User = await _context.User.FindAsync(id);
            if (User == null){
                return NotFound();
            }
            _context.User.Remove(User);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool UserExists(int id){
            return (_context.User?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}
