using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using TTTAPI.JWT.Managers;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalArtistAsocController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IJwtService _jwtService;
        private readonly IFestivalArtistAsocService _festivalArtistAsocService;

        public FestivalArtistAsocController(APIContext context, IMapper mapper, IHttpContextAccessor httpContext, IJwtService jwtService, IFestivalArtistAsocService festivalArtistAsocService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _jwtService = jwtService;
            _festivalArtistAsocService = festivalArtistAsocService;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FestivalArtistDto>>> GetConcert()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcert(int id)
        {         
            var Concert = await _context.Concert.FindAsync(id);
            if(Concert == null){
                return NotFound(new { Message = "El concierto no se ha encontrado"});
            }
            return Concert;
        }

        [HttpPost()]
        public async Task<ActionResult> PostFestivalArtist(FestivalArtistDto festivalArtistDto)
        {
            try 
            {
                if(festivalArtistDto.NuevosArtistas.Count > 0 && festivalArtistDto.ArtistasEliminados.Count > 0)
                {
                    await _festivalArtistAsocService.UpdateFestivalWithArtists(festivalArtistDto);
                     return Ok(new { Message = "Artistas actualizados con éxito"});
                }
                else
                {
                    if(festivalArtistDto.NuevosArtistas.Count > 0)
                    {
                        await _festivalArtistAsocService.CreateFestivalWithArtists(festivalArtistDto);
                         return Ok(new { Message = "Artistas añadidos con éxito"});
                    }
                    else
                    {
                        await _festivalArtistAsocService.DeleteFestivalFromArtist(festivalArtistDto);
                         return Ok(new { Message = "Artistas eliminados con éxito"});
                    }
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutConcert(int id, FestivalArtistDto festivalArtistDto)
        {

            await _context.SaveChangesAsync();
            return Ok(new { Message = "Concierto actualizado con éxito"});
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFestivalArtist(FestivalArtistDto festivalArtistDto)
        {
            try {
                await _festivalArtistAsocService.DeleteFestivalFromArtist(festivalArtistDto);
                return Ok(new { Message = "Artistas eliminados"});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}