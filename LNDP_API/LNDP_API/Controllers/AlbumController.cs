using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : GenericController<Album>
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService): base(albumService)
        {
            _albumService = albumService;
        }
 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            try{
                return Ok(await _albumService.GetAlbums());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

    }
}