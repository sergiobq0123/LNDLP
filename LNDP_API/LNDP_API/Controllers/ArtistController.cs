using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using TTTAPI.Utils;

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
            .Where(u => u.IsActive)
            .Include(u => u.Crew)
            .Include(u => u.SocialNetwork)
            .ToListAsync();
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
        [HttpGet("withoutUser")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistWithoutU()
        {
            if(_context.Artist == null){
                return NotFound();
            }
            return await _context.Artist
            .Where(u => u.IsActive)
            .Where(u => u.UserId == null)
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

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetFilteredArtist([FromBody] List<Filter> filters)
        {
            if (_context.Artist == null)
            {
                return NotFound();
            }

            Expression<Func<Artist, bool>> predicate = FilterUtils.GetPredicate<Artist>(filters);
            return await _context.Artist.Where(predicate.And(p=> p.IsActive)).ToListAsync();
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

        [HttpPost("postImage/{id}")]
        public async Task<ActionResult> PostArtistImage(int id, [FromForm] IFormFile? image)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets");
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(assetsFolderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                artist.Photo = "https://localhost:7032/assets/" + image.FileName;  
            }
            else
            {
                artist.Photo = null;
            }
            await _context.SaveChangesAsync();
            return Ok();
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