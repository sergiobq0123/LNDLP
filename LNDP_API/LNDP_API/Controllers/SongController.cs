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
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongIntranet()
        {
            try{
                return Ok(await _songService.GetSong());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostSong(Song song)
        {
            try{
                Song s = await _songService.CreateSong(song);
                return Ok(new { Message = "Canción creada con éxito", s});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSong(int id, Song song)
        {
            if (!await _songService.ExistSong(id))
            {
                return BadRequest(new { Message = "La canción especificada no existe."});
            }
            try{
                Song s = await _songService.UpdateSong(song);
                return Ok(new { Message = "Canción actualizada con éxito.", s});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            if (!await _songService.ExistSong(id))
            {
                return BadRequest(new { Message = "la canción especificada no existe." });
            }
            try{
                await _songService.DeleteSong(id);
                return Ok(new { Message = "Canción eliminada con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}