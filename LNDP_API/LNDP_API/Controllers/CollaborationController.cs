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
    public class CollaborationController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CollaborationController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collaboration>>> GetCollaboration()
        {
            if(_context.Collaboration == null){
                return NotFound();
            }
            return await _context.Collaboration
            .AsNoTracking()
            .ToListAsync();

        }

        [HttpGet("Cards")]
        public async Task<ActionResult<IEnumerable<GenericCardDto>>> GetCollabsCards()
        {
            if(_context.Collaboration == null){
                return NotFound();
            }
            return await _context.Collaboration
            .AsNoTracking()
            .Select(a => new GenericCardDto {
                PhotoUrl = a.Photo,
                Name = a.Name,
                Description = a.Description,
                BotonUrl = a.Url
            })
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collaboration>> GetCollaboration(int id)
        {         
            var Collaboration = await _context.Collaboration.FindAsync(id);
            if(Collaboration == null){
                return NotFound();
            }
            return Collaboration;
        }

        [HttpPost]
        public async Task<ActionResult<Collaboration>> PostCollaboration([FromForm] IFormFile? image, [FromForm] string Collaboration)
        {
            Collaboration CollaborationData = JsonConvert.DeserializeObject<Collaboration>(Collaboration);
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Collaborations");
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

                var CollaborationNew = new Collaboration
                {
                    Name = CollaborationData?.Name,
                    Photo = "https://localhost:7032/assets/Collaborations/" + fileName,
                    Description = CollaborationData?.Description,
                    Url = CollaborationData?.Url
                };
                _context.Collaboration.Add(CollaborationNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Colaboración añadida con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCollaboration(int id, Collaboration Collaboration)
        {
            if(id != Collaboration.Id){
                return BadRequest(new { Message = "La colaboración no se ha encontrado"});
            }
            _context.Entry(Collaboration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Colaboración actualizada con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollaboration(int id)
        {
            var Collaboration = await _context.Collaboration.FindAsync(id);
            if(Collaboration == null){
                return NotFound(new { Message = "La colaboración no se ha encontrado"});
            }
            
            _context.Collaboration.Remove(Collaboration);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Colaboración borrada con exito"});
        }
    }
}