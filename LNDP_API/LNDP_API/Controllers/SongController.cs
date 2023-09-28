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
    public class SongController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public SongController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSong()
        {
            if(_context.Song == null){
                return NotFound();
            }
            return await _context.Song
            .Include( c => c.Artist)
            .ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {         
            var Song = await _context.Song.FindAsync(id);
            if(Song == null){
                return NotFound(new { Message = "La cancion no se ha encontrado"});
            }
            return Song;
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Canción añadida con éxito"});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSong(int id, Song Song)
        {
            if(id != Song.Id){
                return BadRequest(new { Message = "La cancion no se ha encontrado"});
            }
            _context.Entry(Song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Canción actualizada con éxito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if(song == null){
                return NotFound(new { Message = "La cancion no se ha encontrado"});
            }
            
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Canción borrada con éxito"});
        }
    }
}