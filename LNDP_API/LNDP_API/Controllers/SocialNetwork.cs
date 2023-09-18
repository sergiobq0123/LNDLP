using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using AutoMapper;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public SocialNetworkController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialNetwork>>> GetSocialNetwork()
        {
            if(_context.SocialNetwork == null){
                return NotFound();
            }
            return await _context.SocialNetwork
            .Include( s => s.Artist)
            .ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SocialNetwork>> GetSocialNetwork(int id)
        {         
            var SocialNetwork = await _context.SocialNetwork.FindAsync(id);
            if(SocialNetwork == null){
                return NotFound();
            }
            return SocialNetwork;
        }


        [HttpPost]
        public async Task<ActionResult<SocialNetwork>> PostSocialNetwork(SocialNetworkDto socialNetworkDto)
        {   
            var artist = await _context.Artist.FindAsync(socialNetworkDto.ArtistId);
            if(artist == null){
                return BadRequest(new { Message = "Artista no encontrado" });
            }else{
                var socialNetwork = _mapper.Map<SocialNetwork>(socialNetworkDto);
                socialNetwork.Artist = artist;
                _context.SocialNetwork.Add(socialNetwork);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Redes sociales creadas para " + artist.Name });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSocialNetwork(int id, SocialNetwork SocialNetwork)
        {
            if(id != SocialNetwork.Id){
                return BadRequest(new { Message = "La red social no coincide con el id"});
            }
            _context.Entry(SocialNetwork).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok( new { Message = "Red social actualiza con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSocialNetwork(int id)
        {
            var artist = _context.Artist.Include(a => a.SocialNetwork).FirstOrDefault(a => a.SocialNetworkId == id);
            var socialNetwork = artist?.SocialNetwork;
            if(artist == null || socialNetwork == null){
                return BadRequest(new { Message = "Error al eliminar Red Social" });
            }
            artist.SocialNetworkId = null;
            _context.SocialNetwork.Remove(socialNetwork);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Red Social eliminada para " + artist.Name });
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<SocialNetwork>>> GetFilteredSN([FromBody] List<Filter> filters)
        {
            if (_context.SocialNetwork == null)
            {
                return NotFound();
            }
            Expression<Func<SocialNetwork, bool>> predicate = FilterUtils.GetPredicate<SocialNetwork>(filters);
            return await _context.SocialNetwork.Where(predicate).ToListAsync();
        }
    }
}