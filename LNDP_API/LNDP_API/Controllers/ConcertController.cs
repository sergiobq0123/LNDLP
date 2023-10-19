using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using TTTAPI.JWT.Managers;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IJwtService _jwtService;
        private readonly IConcertService _concertService;

        public ConcertController(APIContext context, IMapper mapper, IHttpContextAccessor httpContext, IConcertService concertService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _concertService = concertService;
        }
 
        [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcert()
        {
            try{
                return Ok(await _concertService.GetConcert());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [AllowAnonymous]
        [HttpGet("proximos-conciertos")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertProximosConciertos()
        {
            try{
                return Ok(await _concertService.GetFutureConcerts());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        // TODO change to role crew y probarlo
        [Authorize(Roles = "Admin")]
        [HttpGet("artist-id")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertArtistId(int artistId)
        {
            try{
                return Ok(await _concertService.GetConcertForArtist(artistId));
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcert(int id)
        {         
            var Concert = await _context.Concert.FindAsync(id);
            if(Concert == null){
                return NotFound(new { Message = "El concierto no se ha encontrado"});
            }
            return Concert;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostConcert(Concert concert)
        {
            try{
                Concert c = await _concertService.CreateConcert(concert);
                return Ok(new { Message = "Concierto creado con éxito", c});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutConcert(int id, Concert concert)
        {
            if (!await _concertService.ExistConcert(id))
            {
                return BadRequest(new { Message = "El concierto especificado no existe."});
            }
            try{
                Concert s = await _concertService.UpdateConcert(concert);
                return Ok(new { Message = "concierto actualizado con éxito.", s});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConcert(int id)
        {
            if (!await _concertService.ExistConcert(id))
            {
                return BadRequest(new { Message = "la canción especificada no existe." });
            }
            try{
                await _concertService.DeleteConcert(id);
                return Ok(new { Message = "Canción eliminada con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}