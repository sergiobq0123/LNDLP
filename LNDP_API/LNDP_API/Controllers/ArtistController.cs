using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using LNDP_API.Services;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;

        public ArtistController(APIContext context, IMapper mapper, IArtistService artistService)
        {
            _context = context;
            _mapper = mapper;
            _artistService = artistService;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtist()
        {
            if(_context.Artist == null){
                return NotFound();
            }
            return await _context.Artist
            .Include(u => u.Crew)
            .Include(u => u.SocialNetwork)
            .Include(u => u.Songs)
            .Include(u => u.Albums)
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
            return await _context.Artist.Where(predicate).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {         
            var artist = await _context.Artist
                .Include(a => a.SocialNetwork)   
                .Include(a => a.Crew)   
                .Include(a => a.Songs)   
                .Include(a => a.Albums)
                .Include(a => a.Events)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if(artist == null){
                return NotFound(new { Message = "El artista no se ha encontrado" });
            }
            return artist;
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist([FromBody] ArtistDto artistDto)
        {
            var artist = await _artistService.CreateArtist(artistDto);
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Artista creado con éxito" });
        }

        [HttpPost("postImage/{id}")]
        public async Task<ActionResult> PostArtistImage(int id, [FromForm] IFormFile? image)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return BadRequest(new { Message = "No se encuentra el artista" });
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
            return Ok(new { Message = "Imagen eliminada para " + artist.Name });
        }

        

        [HttpPut("{id}")]
        public async Task<ActionResult> PutArtist(int id, Artist Artist)
        {
            if(id != Artist.Id){
                return BadRequest(new { Message = "El artista no se ha encontrado" });
            }
            _context.Entry(Artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Artista actualizado con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            var Artist = await _context.Artist.FindAsync(id);
            if(Artist == null){
                return NotFound(new { Message = "El artista no se ha encontrado" });
            }
            _context.Artist.Remove(Artist);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Artista borrado con éxito"});
        }

        private bool ArtistExists(int id){
            return (_context.Artist?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}