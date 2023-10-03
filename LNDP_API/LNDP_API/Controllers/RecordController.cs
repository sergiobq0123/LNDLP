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
    public class RecordController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public RecordController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordDto>>> GetRecord()
        {
            if(_context.Record == null){
                return NotFound();
            }
            return await _context.Record
            .AsNoTracking()
            .Select(a => _mapper.Map<RecordDto>(a))
            .ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {         
            var Record = await _context.Record.FindAsync(id);
            if(Record == null){
                return NotFound();
            }
            return Record;
        }

        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord([FromForm] IFormFile? image, [FromForm] string Record)
        {
            Record RecordData = JsonConvert.DeserializeObject<Record>(Record);
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/Records");
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

                var RecordNew = new Record
                {
                    Name = RecordData?.Name,
                    Photo = "https://localhost:7032/assets/Records/" + fileName,
                    Description = RecordData?.Description,
                    Url = RecordData?.Url
                };
                _context.Record.Add(RecordNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Sello añadido con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutRecord(int id, Record Record)
        {
            if(id != Record.Id){
                return BadRequest(new { Message = "El sello no se ha encontrado"});
            }
            _context.Entry(Record).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Sello actualizado con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecord(int id)
        {
            var Record = await _context.Record.FindAsync(id);
            if(Record == null){
                return NotFound(new { Message = "El sello no se ha encontrado"});
            }
            
            _context.Record.Remove(Record);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Sello borrado con exito"});
        }
    }
}