using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using LNDP_API.Dtos;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CompanyTypeController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyTypeIntranetDto>>> GetCompany()
        {         
            return await _context.CompanyType
            .AsNoTracking()
            .Select(c => _mapper.Map<CompanyTypeIntranetDto>(c))
            .ToListAsync();
        }
    }
}