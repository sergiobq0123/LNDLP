using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
 
        [AllowAnonymous]
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<AlbumWebDto>>> GetAlbum(string type)
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumIntranet()
        {
            try{
                return Ok(await _albumService.GetAlbum());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostAlbum(Album album)
        {
            try{
                Album c = await _albumService.CreateAlbum(album);
                return Ok(new { Message = "Album creado con éxito", c});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAlbum(int id, Album album)
        {
            if (!await _albumService.ExistAlbum(id))
            {
                return BadRequest(new { Message = "El album especificado no existe."});
            }
            try{
                Album c = await _albumService.UpdateAlbum(album);
                return Ok(new { Message = "Album actualizado con éxito.", c});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            if (!await _albumService.ExistAlbum(id))
            {
                return BadRequest(new { Message = "El album especificado no existe." });
            }
            try{
                await _albumService.DeleteAlbum(id);
                return Ok(new { Message = "Album eliminado con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}