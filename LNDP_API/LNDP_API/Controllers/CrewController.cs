using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using AutoMapper;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CrewController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crew>>> GetCrew()
        {
            if(_context.Crew == null){
                return NotFound();
            }
            return await _context.Crew
            .Include( c => c.Artist)
            .ToListAsync();

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
        public async Task<ActionResult<Crew>> PostCrew(CrewDto crewDto)
        {
            var artist = await _context.Artist.FindAsync(crewDto.ArtistId);
            if(artist == null){
                return BadRequest(new { Message = "Artista no encontrado" });
            }
            var crew = _mapper.Map<Crew>(crewDto);
            crew.Artist = artist;
            _context.Crew.Add(crew);
            await _context.SaveChangesAsync();
            return Ok( new { Message = "Equipo creado para " + artist.Name });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCrew(int id, Crew Crew)
        {
            if(id != Crew.Id){
                return BadRequest(new { Message = "El equipo no coincide con el id"});
            }
            _context.Entry(Crew).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Equipo actualizo con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCrew(int id)
        {
            // var artist = _context.Artist.Include(a => a.Crew).FirstOrDefault(a => a.CrewId == id);
            // var crew = artist?.Crew;
            // if(artist == null || crew == null){
            //     return BadRequest(new { Message = "Error al eliminar Red Social" });
            // }
            // artist.Crew = null;
            // _context.Crew.Remove(crew);
            // await _context.SaveChangesAsync();
             return Ok(new { Message = "Equipo eliminada para " });

        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Crew>>> GetFilteredCrew([FromBody] List<Filter> filters)
        {
            if (_context.Crew == null)
            {
                return NotFound();
            }

            Expression<Func<Crew, bool>> predicate = FilterUtils.GetPredicate<Crew>(filters);
            return await _context.Crew.Where(predicate).ToListAsync();
        }
    }
}