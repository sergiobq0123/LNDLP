using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using LNDP_API.Services;
using AutoMapper;
using LNDP_API.Utils.PasswordHasher;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UserController(APIContext context, IAuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistrerDto>>> GetUsers()
        {
            if(_context.User == null){
                return NotFound();
            }
            return await _context.User
            .Include(u => u.UserRole)
            .Select( u => _mapper.Map<UserRegistrerDto>(u))
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
                return BadRequest(new { e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, UserRegistrerDto userRegistrerDto)
        {
            try{
                User user = await _authService.UpdateUser(userRegistrerDto);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Usuario actializado con éxito"});
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
