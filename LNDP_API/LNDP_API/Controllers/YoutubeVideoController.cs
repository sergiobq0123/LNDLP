using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeVideoController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IUrlEmbedService _urlEmbedService;
        private readonly IMapper _mapper;

        public YoutubeVideoController(APIContext context, IUrlEmbedService urlEmbedService, IMapper mapper)
        {
            _context = context;
            _urlEmbedService = urlEmbedService;
            _mapper = mapper;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YoutubeVideo>>> GetYoutubeVideo()
        {
            var videos = await _context.YoutubeVideo
            .Select(s => new {
                s.Name,
                s.Url
            })
            .ToListAsync();

            return Ok(videos);
        }

        [HttpGet("intranet")]
        public async Task<ActionResult<IEnumerable<YoutubeVideo>>> GetYoutubeVideoIntranet()
        {
            return await _context.YoutubeVideo
            .AsNoTracking()
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<YoutubeVideo>> GetYoutubeVideo(int id)
        {         
            var YoutubeVideo = await _context.YoutubeVideo.FindAsync(id);
            if(YoutubeVideo == null){
                return NotFound(new { Message = "El video no se ha encontrado"});
            }
            return YoutubeVideo;
        }

        [HttpPost]
        public async Task<ActionResult> PostYoutubeVideo(YoutubeVideo YoutubeVideo)
        {
            YoutubeVideo.Url = _urlEmbedService.GetEmbedUrlYoutube(YoutubeVideo.Url);
            _context.YoutubeVideo.Add(YoutubeVideo);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Video añadido con éxito" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutYoutubeVideo(int id, YoutubeVideo YoutubeVideo)
        {
            YoutubeVideo.Url = _urlEmbedService.GetEmbedUrlYoutube(YoutubeVideo.Url);
            _context.Entry(YoutubeVideo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Video actualizado con éxito"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteYoutubeVideo(int id)
        {
            var YoutubeVideo = await _context.YoutubeVideo.FindAsync(id);
            if (YoutubeVideo == null)
            {
                return NotFound();
            }
            _context.YoutubeVideo.Remove(YoutubeVideo);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Video borrado con éxito" });
        }
    }
}