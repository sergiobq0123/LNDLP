using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Controllers
{
    [Route("api/user")]
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
            return await _context.User.Where(u => u.IsActive).ToListAsync();

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
