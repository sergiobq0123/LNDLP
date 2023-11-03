using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;
using LNDP_API.Filters;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : GenericController<Album>
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService) : base(albumService)
        {
            _albumService = albumService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<Album>>> GetAlbumsIntranet([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _albumService.GetAlbums(paginationFilter, Request.Path.Value, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("filter")]
        public virtual async Task<ActionResult<IEnumerable<Album>>> PostAlbumsIntranet([FromQuery] PaginationFilter paginationFilter, [FromBody] List<Filter> filters)
        {
            try
            {
                return Ok(await _albumService.GetAlbums(paginationFilter, Request.Path.Value, filters));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}