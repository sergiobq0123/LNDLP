using Microsoft.AspNetCore.Mvc;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using LNDP_API.Dtos;
using AutoMapper;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistIntranet()
        {
            try{
                return Ok(await _artistService.GetArtist());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("keys")]
        public async Task<ActionResult<IEnumerable<KeysIntranetDto>>> GetArtistKeys()
        {
            try{
                return Ok(await _artistService.GetArtistKeys());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostArtist(Artist artist)
        {
            try{
                Artist a = await _artistService.CreateArtist(artist);
                return Ok(new { Message = "Artista creado con éxito", a});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutArtist(int id, Artist artist)
        {
            if (!await _artistService.ExistArtist(id))
            {
                return BadRequest(new { Message = "El artista especificado no existe."});
            }
            try{
                Artist a = await _artistService.UpdateArtist(artist);
                return Ok(new { Message = "Artista actualizado con éxito.", a});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            if (!await _artistService.ExistArtist(id))
            {
                return BadRequest(new { Message = "El artista especificado no existe." });
            }
            try{
                await _artistService.DeleteArtist(id);
                return Ok(new { Message = "Artista eliminado con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ArtistWebDetailDto>> GetArtist(int id)
        // {
        //     var fechaActualUtc = DateTime.UtcNow; 

        //     var artist = await _context.Artist
        //         .Include(a => a.Songs)
        //         .Include(a => a.Albums)
        //         .Include(a => a.Concerts)
        //         .AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);

        //     artist.Concerts = artist.Concerts.Where(c => c.Date >= fechaActualUtc).ToList();
        //     artist.Concerts = artist.Concerts.OrderBy(c => c.Date).ToList();
        //     artist.Songs = artist.Songs.OrderBy(s => s.Name).ToList();
        //     return _mapper.Map<ArtistWebDetailDto>(artist);
        // }
        
    }
}