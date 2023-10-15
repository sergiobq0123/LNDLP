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
        private readonly IImageService _imageService;

        public ArtistController(APIContext context, IMapper mapper, IArtistService artistService, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _artistService = artistService;
            _imageService = imageService;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistWebGenericDto>>> GetArtist()
        {
            return await _context.Artist
            .Include(a => a.SocialNetwork)
            .Select(a => _mapper.Map<ArtistWebGenericDto>(a))
            .ToListAsync();
        }

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<ArtistGetDto>>> GetArtistIntranet()
        {
            var artists = await _context.Artist
            .Include(a => a.SocialNetwork)
            .AsNoTracking()
            .ToListAsync();

            return Ok(_mapper.Map<ICollection<ArtistGetDto>>(artists));
        }

        [HttpGet("keys")]
        public async Task<ActionResult<IEnumerable<ArtistIntranetNameDto>>> GetArtistKeys()
        {
            var artists = await _context.Artist
            .AsNoTracking()
            .ToListAsync();

            return Ok(_mapper.Map<ICollection<ArtistIntranetNameDto>>(artists));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistWebDetailDto>> GetArtist(int id)
        {
            var fechaActualUtc = DateTime.UtcNow; 

            var artist = await _context.Artist
                .Include(a => a.Songs)
                .Include(a => a.Albums)
                .Include(a => a.Concerts)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            artist.Concerts = artist.Concerts.Where(c => c.Date >= fechaActualUtc).ToList();
            artist.Concerts = artist.Concerts.OrderBy(c => c.Date).ToList();
            artist.Songs = artist.Songs.OrderBy(s => s.Name).ToList();
            return _mapper.Map<ArtistWebDetailDto>(artist);
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


        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist([FromBody] ArtistCreateDto artistCreateDto)
        {
            try
            {
                var artist = await _artistService.CreateArtist(artistCreateDto);
                _context.Artist.Add(artist);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Artista creado con éxito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutArtist(int id, ArtistGetDto artistGetDto)
        {
            try
            {
                Artist artist = await _context.Artist.Where(c => c.Id == id).FirstOrDefaultAsync();
                if(artist.PhotoUrl != artistGetDto.PhotoUrl){
                    artistGetDto.PhotoUrl = await _imageService.ConvertBase64ToUrl(artistGetDto.PhotoUrl, artistGetDto.Name);
                }
                _context.Entry(artist).CurrentValues.SetValues(artistGetDto);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Artista actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error al actualizar el artista: " + ex.Message });
            }
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