using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
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
                var company = await _companyService.GetCompany();
                return Ok(await _companyService.GetCompany());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostCompany(Company company)
        {
            try{
                Company c = await _companyService.CreateCompany(company);
                return Ok(new { Message = "Empresa creada con éxito", c});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, Company company)
        {
            if (!await _companyService.ExistCompany(id))
            {
                return BadRequest(new { Message = "La empresa especificada no existe."});
            }
            try{
                Company c = await _companyService.UpdateCompany(company);
                return Ok(new { Message = "Empresa actualizada con éxito.", c});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            if (!await _companyService.ExistCompany(id))
            {
                return BadRequest(new { Message = "La empresa especificada no existe." });
            }
            try{
                await _companyService.DeleteCompany(id);
                return Ok(new { Message = "Empresa eliminada con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}