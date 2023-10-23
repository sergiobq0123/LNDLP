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
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {
            try{
                return Ok(await _artistService.GetArtists());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-register")]
        public async Task<ActionResult<Artist>> PostArtist(ArtistCreateDto artistCreateDto)
        {
            try{
                Artist artist = await _artistService.PostArtist(artistCreateDto);
                return Ok(new { Message = "Artista creado(a) con éxito.", artist });
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistWebDetailDto>> GetArtist(int id)
        {
            try{
                return Ok(await _artistService.GetArtistById(id));
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}