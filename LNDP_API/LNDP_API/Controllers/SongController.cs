using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : GenericController<Song>
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService) : base(songService)
        {
            _songService = songService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongIntranet([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _songService.GetSongs(paginationFilter, Request.Path.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}