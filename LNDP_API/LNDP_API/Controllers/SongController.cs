using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public SongController(APIContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongIntranetDto>>> GetSong()
        {
            return await _context.Song
            .Include( c => c.Artist)
            .Select( s => _mapper.Map<SongIntranetDto>(s))
            .ToListAsync();
        }

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<SongIntranetDto>>> GetSongIntranet()
        {
            return await _context.Song
            .Include( c => c.Artist)
            .AsNoTracking()
            .Select( s => _mapper.Map<SongIntranetDto>(s))
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
        public async Task<ActionResult> PostSong(SongIntranetDto songIntranetDto)
        {
            Song song = _mapper.Map<Song>(songIntranetDto);
            song.Artist = _context.Artist.Find(songIntranetDto.ArtistId);
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Canción añadida con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSong(int id, SongIntranetDto songIntranetDto)
        {
            _context.Entry(_mapper.Map<Song>(songIntranetDto)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Canción actualizada con éxito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Canción borrada con éxito" });
        }
    }
}