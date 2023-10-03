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
    public class BrandController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public BrandController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrand()
        {
            if(_context.Brand == null){
                return NotFound();
            }
            return await _context.Brand
            .AsNoTracking()
            .Select(a => _mapper.Map<BrandDto>(a))
            .ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {         
            var Brand = await _context.Brand.FindAsync(id);
            if(Brand == null){
                return NotFound();
            }
            return Brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand([FromForm] IFormFile? image, [FromForm] string Brand)
        {
            Brand BrandData = JsonConvert.DeserializeObject<Brand>(Brand);
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Brands");
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

                var BrandNew = new Brand
                {
                    Name = BrandData?.Name,
                    Photo = "https://localhost:7032/assets/Brands/" + fileName,
                    Description = BrandData?.Description,
                    Url = BrandData?.Url
                };
                _context.Brand.Add(BrandNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Marca añadida con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBrand(int id, Brand Brand)
        {
            if(id != Brand.Id){
                return BadRequest(new { Message = "La marca no se ha encontrado"});
            }
            _context.Entry(Brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Marca actualizada con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var Brand = await _context.Brand.FindAsync(id);
            if(Brand == null){
                return NotFound(new { Message = "La marca no se ha encontrado"});
            }
            
            _context.Brand.Remove(Brand);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Marca borrada con exito"});
        }
    }
}