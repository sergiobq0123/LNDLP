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

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSocialNetwork(int id, SocialNetwork SocialNetwork)
        {
            _context.Entry(SocialNetwork).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok( new { Message = "Red social actualizada con exito"});
        }

    }
}