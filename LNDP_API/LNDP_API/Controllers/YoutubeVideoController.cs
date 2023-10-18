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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YoutubeVideo>>> GetYoutubeVideoIntranet()
        {
            try{
                return Ok(await _youtubeVideoService.GetYoutubeVideo());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            try{
                YoutubeVideo yb = await _youtubeVideoService.CreateYotubeVideo(youtubeVideo);
                return Ok(new { Message = "Video de youtube creado con éxito", yb});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutYoutubeVideo(int id, YoutubeVideo youtubeVideo)
        {
            if (!await _youtubeVideoService.ExistYoutubeVideo(id))
            {
                return BadRequest(new { Message = "El video de youtube especificado no existe."});
            }
            try{
                YoutubeVideo yb = await _youtubeVideoService.UpdateYoutubeVideo(youtubeVideo);
                return Ok(new { Message = "Video de youtube actualizado con éxito.", yb});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteYoutubeVideo(int id)
        {
            if (!await _youtubeVideoService.ExistYoutubeVideo(id))
            {
                return BadRequest(new { Message = "El video de youtube especificado no existe." });
            }
            try{
                await _youtubeVideoService.DeleteYoutubeVideo(id);
                return Ok(new { Message = "Video de youtube eliminado con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}