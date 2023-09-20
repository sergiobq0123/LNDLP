using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIContext _context;

        public UserController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if(_context.User == null){
                return NotFound();
            }
            return await _context.User
            .Include(u => u.UserRole)
            .Include(u => u.Artist)
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
        public async Task<ActionResult<User>> PostUsers(User user)
        {

            if(_context.User == null){
                return NotFound();
            }
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsers(int id, User user)
        {
            if(id != user.Id){
                return BadRequest();
            }
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if(!UserExists(id)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return NoContent();
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
