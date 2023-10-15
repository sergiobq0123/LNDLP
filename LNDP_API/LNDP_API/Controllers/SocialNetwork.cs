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

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSocialNetwork(int id, SocialNetwork SocialNetwork)
        {
            if(id != SocialNetwork.Id){
                return BadRequest(new { Message = "La red social no coincide con el id"});
            }
            _context.Entry(SocialNetwork).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok( new { Message = "Red social actualizada con exito"});
        }

    }
}