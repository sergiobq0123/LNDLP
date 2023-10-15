using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using TTTAPI.Utils;
using System.Linq.Expressions;
using LNDP_API.Services;
using LNDP_API.Dtos;
using AutoMapper;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public EventController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("type/{tipo}")]
        public async Task<ActionResult<IEnumerable<GenericCardDto>>> GetEvent(string tipo)
        {
            return await _context.Event
            .Include( e => e.EventType)
            .Include( e => e.Artist)
            .AsNoTracking()
            .Where(e => e.EventType.EventName == tipo)
            .Select(e => _mapper.Map<GenericCardDto>(e))
            .ToListAsync();
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

        private async Task<ActionResult<IEnumerable<Event>>> GetEventsForDefaultUser(string tipo)
        {
            return await _context.Event
                .Where(u => u.EventType.EventName == tipo)
                .ToListAsync();
        }
    }
}