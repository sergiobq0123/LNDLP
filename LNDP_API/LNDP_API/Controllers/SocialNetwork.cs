using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/socialnetwork")]
    [ApiController]
    public class SocialNetworkController : ControllerBase
    {
        private readonly APIContext _context;

        public SocialNetworkController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialNetwork>>> GetSocialNetwork()
        {
            if(_context.SocialNetwork == null){
                return NotFound();
            }
            return await _context.SocialNetwork
            .Where(u => u.IsActive).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SocialNetwork>> GetSocialNetwork(int id)
        {         
            var SocialNetwork = await _context.SocialNetwork.FindAsync(id);
            if(SocialNetwork == null){
                return NotFound();
            }
            return SocialNetwork;
        }

        [HttpPost]
        public async Task<ActionResult<SocialNetwork>> PostSocialNetwork(SocialNetwork SocialNetwork)
        {
            _context.SocialNetwork.Add(SocialNetwork);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSocialNetwork", new { id = SocialNetwork.Id }, SocialNetwork);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSocialNetwork(int id, SocialNetwork SocialNetwork)
        {
            if(id != SocialNetwork.Id){
                return BadRequest();
            }
            _context.Entry(SocialNetwork).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!SocialNetworkExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSocialNetwork(int id)
        {
            if(_context.SocialNetwork == null){
                return NotFound();
            }
            var SocialNetwork = await _context.SocialNetwork.FindAsync(id);
            if (SocialNetwork == null){
                return NotFound();
            }
            _context.SocialNetwork.Remove(SocialNetwork);
            await _context.SaveChangesAsync();

            return Ok("SocialNetwork borrado con éxito");
        }

        private bool SocialNetworkExists(int id){
            return (_context.SocialNetwork?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}