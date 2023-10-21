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
    public class ArtistController : GenericController<Artist>
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService): base(artistService)
        {
            _artistService = artistService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistIntranet()
        {
            try{
                return Ok(await _artistService.Get());
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