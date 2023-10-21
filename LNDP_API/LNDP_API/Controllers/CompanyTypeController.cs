using LNDP_API.Dtos;
using LNDP_API.Services;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeController(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompany()
        {         
            return Ok(await _companyTypeService.Get());
        }

        [AllowAnonymous]
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<AlbumWebDto>>> GetAlbum(string type)
        {
            return Ok(_companyTypeService.Get(
                filter: c => c.CompanyTypeName == type
            ));
        }
    }
}