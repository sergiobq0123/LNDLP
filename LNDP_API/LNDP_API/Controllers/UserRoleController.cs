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
    public class UserRoleController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public UserRoleController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("keys")]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetUsers()
        {
            return await _context.UserRole
            .Where(u => u.Id != 3)
            .Select( u => _mapper.Map<UserRoleDto>(u))
            .ToListAsync();
        }
    }
}
