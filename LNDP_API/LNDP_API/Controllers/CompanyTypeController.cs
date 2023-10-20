using Microsoft.AspNetCore.Mvc;
using LNDP_API.Dtos;
using LNDP_API.Services;
using LNDP_API.Models;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompany()
        {         
            return Ok(await _companyTypeService.GetCompanyType());
        }
    }
}