using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : GenericController<Company>
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService): base(companyService)
        {
            _companyService = companyService;
        }
 
        [AllowAnonymous]
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<CompanyWebDto>>> GetCompany(string type)
        {
            var CompanyDtos = await _companyService.GetCompanyType(type);
            return Ok(CompanyDtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyIntranet()
        {
            try{
                return Ok(await _companyService.Get());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}