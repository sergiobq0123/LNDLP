using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using Newtonsoft.Json;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CompanyController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyIntranetDto>>> GetCompany()
        {
            if(_context.Company == null){
                return NotFound();
            }
            return await _context.Company
            .AsNoTracking()
            .Include(c => c.CompanyType)
            .Select(c => _mapper.Map<CompanyIntranetDto>(c))
            .ToListAsync();
        }
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<CompanyIntranetDto>>> GetCompany(string type)
        {
            if(_context.Company == null){
                return NotFound();
            }
            return await _context.Company
            .Include(c => c.CompanyType)
            .AsNoTracking()
            .Where(c => c.CompanyType.CompanyTypeName == type)
            .Select(c => _mapper.Map<CompanyIntranetDto>(c))
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {         
            var Company = await _context.Company.FindAsync(id);
            if(Company == null){
                return NotFound();
            }
            return Company;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany([FromForm] IFormFile? image, [FromForm] string companyIntranetDto)
        {
            CompanyIntranetDto CompanyData = JsonConvert.DeserializeObject<CompanyIntranetDto>(companyIntranetDto);
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Companys");
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(assetsFolderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                var CompanyNew = new Company
                {
                    Name = CompanyData?.Name,
                    PhotoUrl = "https://localhost:7032/assets/Companys/" + fileName,
                    Description = CompanyData?.Description,
                    WebUrl = CompanyData?.WebUrl,
                    CompanyTypeId = CompanyData?.CompanyTypeId
                };
                _context.Company.Add(CompanyNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Empresa añadida con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, Company Company)
        {
            if(id != Company.Id){
                return BadRequest(new { Message = "La empresa no se ha encontrado"});
            }
            _context.Entry(Company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Empresa actualizada con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var Company = await _context.Company.FindAsync(id);
            if(Company == null){
                return NotFound(new { Message = "La empresa no se ha encontrado"});
            }
            
            _context.Company.Remove(Company);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Empresa borrada con exito"});
        }
    }
}