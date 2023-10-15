using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using AutoMapper;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public UserRoleController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoleRole()
        {
            if(_context.UserRole == null){
                return NotFound();
            }
            return await _context.UserRole
            .ToListAsync();

        }

        [HttpGet("keys")]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetUsers()
        {
            return await _context.UserRole
            .Where(u => u.Id != 3)
            .Select( u => _mapper.Map<UserRoleDto>(u))
            .ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {         
            var UserRole = await _context.UserRole.FirstOrDefaultAsync(u => u.Id == id);
    
            if (UserRole == null)
            {
                return NotFound();
            }

            return UserRole;
        }

        // Use Auth
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRoleRole(UserRole UserRole)
        {
            if(_context.UserRole == null){
                return NotFound();
            }
            _context.UserRole.Add(UserRole);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserRole", new { id = UserRole.Id }, UserRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUserRoleRole(int id, UserRole UserRole)
        {
            if(id != UserRole.Id){
                return BadRequest();
            }
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if(!UserRoleExists(id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserRoleRole(int id)
        {
            if(_context.UserRole == null){
                return NotFound();
            }
            var UserRole = await _context.UserRole.FindAsync(id);
            if (UserRole == null){
                return NotFound();
            }
            _context.UserRole.Remove(UserRole);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool UserRoleExists(int id){
            return (_context.UserRole?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}
