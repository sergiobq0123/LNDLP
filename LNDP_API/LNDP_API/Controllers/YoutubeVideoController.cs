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
    public class YoutubeVideoController : GenericController<YoutubeVideo>
    {
        private readonly IYoutubeVideoService _youtubeVideoService;

        public YoutubeVideoController(IYoutubeVideoService youtubeVideoService) : base(youtubeVideoService)
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YoutubeVideo>>> GetYoutubeVideoIntranet()
        {
            try{
                return Ok(await _youtubeVideoService.Get());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}