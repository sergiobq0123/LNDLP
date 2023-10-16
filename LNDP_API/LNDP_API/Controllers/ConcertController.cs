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
    public class ConcertController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IJwtService _jwtService;

        public ConcertController(APIContext context, IMapper mapper, IHttpContextAccessor httpContext, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _jwtService = jwtService;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConcertIntranetDto>>> GetConcert()
        {
            return await _context.Concert
            .Include( c => c.Artist)
            .Select( s => _mapper.Map<ConcertIntranetDto>(s))
            .ToListAsync();
        }

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<ConcertIntranetDto>>> GetConcertIntranet()
        {
            return await _context.Concert
            .Include( c => c.Artist)
            .AsNoTracking()
            .Select( s => _mapper.Map<ConcertIntranetDto>(s))
            .ToListAsync();
        }

        [HttpGet("proximos-conciertos")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertProximosConciertos()
        {
            DateTime fechaActualUtc = DateTime.UtcNow;
            var conciertosProximos = await _context.Concert
                .Include(c => c.Artist)
                .AsNoTracking()
                .Where(c => c.Date >= fechaActualUtc)
                .OrderBy(s => s.Date)
                .Select(c => new
                {
                    c.Name,
                    c.Date,
                    c.City,
                    c.Tickets,
                    c.Artist.PhotoUrl
                })
                .ToListAsync();
            return Ok(conciertosProximos);
        }

        [HttpGet("artist-id")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertArtistId(int userId)
        {
            Artist artist = await _context.Artist.FirstOrDefaultAsync(a => a.User.Id == userId);

            DateTime fechaActualUtc = DateTime.UtcNow.Date;
            var conciertosProximos = await _context.Concert
                .Include(c => c.Artist)
                .AsNoTracking()
                .Where(c => c.Artist.Id == artist.Id && c.Date >= fechaActualUtc)
                .OrderBy(c => c.Date)
                .Select(c => new
                {
                    c.Name,
                    c.City,
                    c.Location,
                    c.UrlLocation,
                    c.Date,
                })
                .ToListAsync();

            return Ok(conciertosProximos);
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

        [HttpPost]
        public async Task<ActionResult> PostConcert(ConcertIntranetDto ConcertIntranetDto)
        {
            Concert Concert = _mapper.Map<Concert>(ConcertIntranetDto);
            Concert.Artist = _context.Artist.Find(ConcertIntranetDto.ArtistId);
            Concert.UrlLocation = Concert.Location;
            _context.Concert.Add(Concert);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Concierto añadido con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutConcert(int id, ConcertIntranetDto ConcertIntranetDto)
        {
            _context.Entry(_mapper.Map<Concert>(ConcertIntranetDto)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Concierto actualizado con éxito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConcert(int id)
        {
            var Concert = await _context.Concert.FindAsync(id);
            if (Concert == null)
            {
                return NotFound();
            }
            _context.Concert.Remove(Concert);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Concierto borrado con éxito" });
        }
    }
}