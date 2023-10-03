using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using System.Linq.Expressions;
using TTTAPI.Utils;
using LNDP_API.Dtos;
using AutoMapper;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public AlbumController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAlbum()
        {
            if(_context.Album == null){
                return NotFound();
            }
            return await _context.Album
            .Include( c => c.Artist)
            .AsNoTracking()
            .Select(a => _mapper.Map<AlbumDto>(a))
            .ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {         
            var Album = await _context.Album.FindAsync(id);
            if(Album == null){
                return NotFound();
            }
            return Album;
        }

        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum([FromForm] IFormFile? image, [FromForm] string album)
        {
            Album albumData = JsonConvert.DeserializeObject<Album>(album);
            if (image != null && image.Length > 0)
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/albumes");
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

                var albumNew = new Album
                {
                    Name = albumData?.Name,
                    Photo = "https://localhost:7032/assets/albumes/" + fileName,
                    ArtistId = albumData?.ArtistId,
                };
                _context.Album.Add(albumNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new { Message = "La imagen no se ha podido cargar" });
            }
            await _context.SaveChangesAsync();
             return Ok(new { Message = "Álbum añadido con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAlbum(int id, Album Album)
        {
            if(id != Album.Id){
                return BadRequest(new { Message = "El álbum no se ha encontrado"});
            }
            _context.Entry(Album).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Álbum actualizado con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            var Album = await _context.Album.FindAsync(id);
            if(Album == null){
                return NotFound(new { Message = "El álbum no se ha encontrado"});
            }
            
            _context.Album.Remove(Album);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Álbum borrado con exito"});
        }
    }
}