using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly APIContext _context;

        public CrewController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crew>>> GetCrew()
        {
            if(_context.Crew == null){
                return NotFound();
            }
            return await _context.Crew.Where(u => u.IsActive).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crew>> GetCrew(int id)
        {         
            var Crew = await _context.Crew.FindAsync(id);
            if(Crew == null){
                return NotFound();
            }
            return Crew;
        }

        [HttpPost]
        public async Task<ActionResult<Crew>> PostCrew(Crew Crew)
        {
            _context.Crew.Add(Crew);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCrew", new { id = Crew.Id }, Crew);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCrew(int id, Crew Crew)
        {
            if(id != Crew.Id){
                return BadRequest();
            }
            _context.Entry(Crew).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!CrewExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCrew(int id)
        {
            if(_context.Crew == null){
                return NotFound();
            }
            var Crew = await _context.Crew.FindAsync(id);
            if (Crew == null){
                return NotFound();
            }
            _context.Crew.Remove(Crew);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CrewExists(int id){
            return (_context.Crew?.Any(u => u.Id == id)).GetValueOrDefault();
        }
    }
}