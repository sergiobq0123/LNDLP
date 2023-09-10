using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly APIContext _context;

        public EventController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            if(_context.Event == null){
                return NotFound();
            }
            return await _context.Event
            .Include(Event => Event.EventType)
            .Where(u => u.IsActive).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {         
            var Event = await _context.Event.FindAsync(id);
            if(Event == null){
                return NotFound();
            }
            return Event;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event Event)
        {
            _context.Event.Add(Event);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEvent", new { id = Event.Id }, Event);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(int id, Event Event)
        {
            if(id != Event.Id){
                return BadRequest();
            }
            _context.Entry(Event).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!EventExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            if(_context.Event == null){
                return NotFound();
            }
            var Event = await _context.Event.FindAsync(id);
            if (Event == null){
                return NotFound();
            }
            _context.Event.Remove(Event);
            await _context.SaveChangesAsync();

            return Ok("Evento borrado con éxito");
        }

        private bool EventExists(int id){
            return (_context.Event?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}