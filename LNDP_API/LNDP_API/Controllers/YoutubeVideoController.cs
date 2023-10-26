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
    public class YoutubeVideoController : ControllerBase
    {
        private readonly IYoutubeVideoService _youtubeVideoService;

        public YoutubeVideoController(IYoutubeVideoService youtubeVideoService)
        {
            _youtubeVideoService = youtubeVideoService;
        }

        [AllowAnonymous]
        [HttpGet("youtube-videos-web")]
        public async Task<ActionResult<IEnumerable<YoutubeVideoWebDto>>> GetYoutubeVideo()
        {
            var youtubeVideoDtos = await _youtubeVideoService.GetYoutubeVideoDto();
            return Ok(youtubeVideoDtos);
        }

        [Authorize(Roles = "Visual")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YoutubeVideo>>> GetYoutubeVideoIntranet([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _youtubeVideoService.Get(paginationFilter, Request.Path.Value));
            }

            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}