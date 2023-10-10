using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using TTTAPI.Utils;
using System.Linq.Expressions;
using LNDP_API.Services;
using LNDP_API.Dtos;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly APIContext _context;

        public EventController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("type/{tipo}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent(string tipo)
        {
            if(_context.Event == null){
                    return NotFound();
            }
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            // var tipoUsuario = _tokenService.ObtenerTipoDeUsuarioDesdeToken(token);
            // switch (tipoUsuario)
            // {
            //     case "Admin":
            //         return await GetEventsForAdmin(tipo);
            //     // case "Crew":
            //     //     return await GetEventsForCrew(tipo, token);
            //     case "TokenInválido":
            //         return BadRequest("El token proporcionado no es válido");
            //     case "UsuarioDesconocido":
            //         return BadRequest("El usuario no es conocido");
            //     default:
            //         return await GetEventsForDefaultUser(tipo);
            // }
            return Ok();
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            if(_context.Event == null){
                return NotFound();
            }
            return await _context.Event
            .Include( e => e.EventType)
            .Include( e => e.Artist)
            .ToListAsync();
        }
        [HttpGet("type/{type}/Cards")]
       public async Task<ActionResult<IEnumerable<GenericCardDto>>> GetEventOrder(string type)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }
            return await _context.Event
                .Include(e => e.EventType)
                .Include(e => e.Artist)
                .Where(e => e.EventType.EventName == type)
                .OrderBy(e => e.Date)
                .Select(e => new GenericCardDto
                {
                    PhotoUrl = e.Artist.Photo,
                    Name = e.Name,
                    Date = e.Date.ToString(),
                    Description = e.City + e.Location, 
                    BotonUrl = e.Tickets 
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event Event)
        {
            var artist = await _context.Artist.FindAsync(Event.ArtistId);
            if(artist == null)
            {
                return BadRequest(new { Message = "Artista no encontrado" });
            }
            Event.UrlLocation = Event.Location;
            _context.Event.Add(Event);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Evento creado para " + artist.Name });
        }

        [HttpPost("type/Festival/filter")]
        public async Task<ActionResult<IEnumerable<Event>>> GetFilteredEventFestival([FromBody] List<Filter> filters)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }

            Expression<Func<Event, bool>> predicate = FilterUtils.GetPredicate<Event>(filters);
            return await _context.Event.Where(predicate).Where(p => p.EventType.EventName == "Festival").ToListAsync();
        }

        [HttpPost("type/Concierto/filter")]
        public async Task<ActionResult<IEnumerable<Event>>> GetFilteredEventConcierto([FromBody] List<Filter> filters)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }

            Expression<Func<Event, bool>> predicate = FilterUtils.GetPredicate<Event>(filters);
            return await _context.Event.Where(predicate).Where(p => p.EventType.EventName == "Concierto").ToListAsync();
        }
        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Event>>> GetFilteredEvent([FromBody] List<Filter> filters)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }

            Expression<Func<Event, bool>> predicate = FilterUtils.GetPredicate<Event>(filters);
            return await _context.Event.Where(predicate).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(int id, Event Event)
        {
            if(id != Event.Id){
                return BadRequest(new { Message = "El evento no coincide con el id"});
            }
            Event.UrlLocation = Event.Location;
            _context.Entry(Event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok( new { Message = "Evento actualizo con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var Event = await _context.Event.FindAsync(id);
            if (Event == null){
                return BadRequest(new { Message = "Error al eliminar evento " });
            }
            _context.Event.Remove(Event);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Evento eliminado"});
        }

        private async Task<ActionResult<IEnumerable<Event>>> GetEventsForAdmin(string tipo)
        {
            return await _context.Event
                .Include( e => e.EventType)
                .Include( e => e.Artist)
                .Where(u => u.EventType.EventName == tipo)
                .ToListAsync();
        }

        // private async Task<ActionResult<IEnumerable<Event>>> GetEventsForCrew(string tipo, string token)
        // {
        //     var userId = _tokenService.ObtenerIdArtistaDesdeToken(token);
        //     var artist = await _context.Artist.FirstOrDefaultAsync(a => a.User.Id == userId);
        //     if (artist != null)
        //     {
        //         return await _context.Event
        //             .Where(e => e.EventType.EventName == tipo)
        //             .Where(e => e.ArtistId == artist.Id)
        //             .ToListAsync();
        //     }
        //     else
        //     {
        //         return await _context.Event
        //             .Where(e => e.EventType.EventName == tipo)
        //             .Where(e => e.ArtistId == artist.Id)
        //             .ToListAsync();
        //     }
        // }

        private async Task<ActionResult<IEnumerable<Event>>> GetEventsForDefaultUser(string tipo)
        {
            return await _context.Event
                .Where(u => u.EventType.EventName == tipo)
                .ToListAsync();
        }
    }
}