using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using Newtonsoft.Json;
using LNDP_API.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CompanyController(APIContext context, IMapper mapper, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
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
        public async Task<ActionResult<Company>> PostCompany(CompanyIntranetDto companyIntranetDto)
        {
            try
            {
                companyIntranetDto.PhotoUrl = await _imageService.ConvertBase64ToUrl(companyIntranetDto.PhotoUrl, companyIntranetDto.Name);
                _context.Company.Add(_mapper.Map<Company>(companyIntranetDto));
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Empresa creada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al crear la empresa", Error = ex.Message });
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompany(int id, CompanyIntranetDto companyIntranetDto)
        {
            try
            {
                Company company = await _context.Company.Where(c => c.Id == id).FirstOrDefaultAsync();
                if(company.PhotoUrl != companyIntranetDto.PhotoUrl){
                    companyIntranetDto.PhotoUrl = await _imageService.ConvertBase64ToUrl(companyIntranetDto.PhotoUrl, companyIntranetDto.Name);
                }
                _context.Entry(company).CurrentValues.SetValues(companyIntranetDto);
                
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Empresa actualizada con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error al actualizar la empresa: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            try
            {
                var company = await _context.Company.FindAsync(id);
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Empresa borrada con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error al eliminar la empresa: " + ex.Message });
            }
        }
    }
}