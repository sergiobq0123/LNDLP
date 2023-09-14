using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly APIContext _context;

        public ArtistController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtist()
        {
            if(_context.Artist == null){
                return NotFound();
            }
            return await _context.Artist
            .Where(u => u.IsActive).ToListAsync();
        }

        [HttpGet("withoutSocialNetWork")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistWithoutSN()
        {
            if(_context.Artist == null){
                return NotFound();
            }
            return await _context.Artist
            .Where(u => u.IsActive)
            .Where(u => u.SocialNetwork == null)
            .ToListAsync();
        }
        [HttpGet("withoutCrew")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistWithoutC()
        {
            if(_context.Artist == null){
                return NotFound();
            }
            return await _context.Artist
            .Where(u => u.IsActive)
            .Where(u => u.Crew == null)
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {         
            var Artist = await _context.Artist.FindAsync(id);
            if(Artist == null){
                return NotFound();
            }
            return Artist;
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist Artist)
        {
            _context.Artist.Add(Artist);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetArtist", new { id = Artist.Id }, Artist);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutArtist(int id, Artist Artist)
        {
            if(id != Artist.Id){
                return BadRequest();
            }
            _context.Entry(Artist).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!ArtistExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            if(_context.Artist == null){
                return NotFound();
            }
            var Artist = await _context.Artist.FindAsync(id);
            if (Artist == null){
                return NotFound();
            }
            _context.Artist.Remove(Artist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ArtistExists(int id){
            return (_context.Artist?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}