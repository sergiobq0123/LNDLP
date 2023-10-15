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
using LNDP_API.Services;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public AlbumController(APIContext context, IMapper mapper, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
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

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<AlbumIntranetDto>>> GetAlbumIntranet()
        {
            return await _context.Album
            .Include( a => a.Artist)
            .AsNoTracking()
            .Select(a => _mapper.Map<AlbumIntranetDto>(a))
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
        public async Task<ActionResult<Company>> PostCompany(AlbumIntranetDto albumIntranetDto)
        {
            try
            {
                albumIntranetDto.PhotoUrl = await _imageService.ConvertBase64ToUrl(albumIntranetDto.PhotoUrl, albumIntranetDto.Name);
                Album album = _mapper.Map<Album>(albumIntranetDto);
                album.Artist = _context.Artist.Find(albumIntranetDto.ArtistId);
                _context.Album.Add(album);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Album creado con éxito"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al crear la album", Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAlbum(int id, AlbumIntranetDto albumIntranetDto)
        {
            try
            {
                Album album = await _context.Album.Where(c => c.Id == id).FirstOrDefaultAsync();
                if(album.PhotoUrl != albumIntranetDto.PhotoUrl){
                    albumIntranetDto.PhotoUrl = await _imageService.ConvertBase64ToUrl(albumIntranetDto.PhotoUrl, albumIntranetDto.Name);
                }
                _context.Entry(album).CurrentValues.SetValues(albumIntranetDto);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Album actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error al actualizar el álbum: " + ex.Message });
            }
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