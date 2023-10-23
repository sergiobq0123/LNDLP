using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using TTTAPI.JWT.Managers;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalArtistAsocController : ControllerBase
    {
        private readonly IArtistFestivalAsocService _artistFestivalAsocService;

        public FestivalArtistAsocController(IArtistFestivalAsocService artistFestivalAsocService)
        {
            _artistFestivalAsocService = artistFestivalAsocService;
        }
 
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> PostFestivalArtist(FestivalArtistDto festivalArtistDto)
        {
            try 
            {
                await _artistFestivalAsocService.UpdateFestivalWithArtists(festivalArtistDto);
                return Ok(new { Message = "Artistas actualizados con éxito."});
            }
            catch(Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
        }
    
        [Authorize(Roles = "Crew")]
        [HttpGet("festival-user-id/{id}")]
        public async Task<ActionResult> GetFestivalforArtist(int id)
        {
            try 
            {
                return Ok(await _artistFestivalAsocService.GetFestivalForArtist(id));
            }
            catch(Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
        }
    }
}