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
    public class FestivalController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IJwtService _jwtService;

        public FestivalController(APIContext context, IMapper mapper, IHttpContextAccessor httpContext, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _jwtService = jwtService;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestival()
        {
            return await _context.Festival
            .ToListAsync();
        }

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<object>>> GetFestivalIntranet()
        {
            var festivals = await _context.Festival
            .Include(f => f.ArtistFestivalAsoc) 
                .ThenInclude(afa => afa.Artist) 
            .AsNoTracking()
            .ToListAsync();

            var result = festivals.Select(festival => new
            {
                festival.Id,
                festival.Name,
                festival.Location,
                festival.Date,
                Artists = festival.ArtistFestivalAsoc.Select(afa => new
                {
                    afa.Artist.Id,
                    afa.Artist.Name
                })
            });

        return Ok(result);
        }

        [HttpGet("proximos-conciertos")]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivalProximosConciertos()
        {
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Festival>> GetFestival(int id)
        {         
            var Festival = await _context.Festival.FindAsync(id);
            if(Festival == null){
                return NotFound(new { Message = "El concierto no se ha encontrado"});
            }
            return Festival;
        }

        [HttpPost]
        public async Task<ActionResult> PostFestival(Festival festival)
        {
            _context.Festival.Add(festival);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Festival añadido con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutFestival(int id, Festival festival)
        {
            _context.Entry(festival).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Festival actualizado con éxito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            var Festival = await _context.Festival.FindAsync(id);
            if (Festival == null)
            {
                return NotFound();
            }
            _context.Festival.Remove(Festival);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Concierto borrado con éxito" });
        }
    }
}