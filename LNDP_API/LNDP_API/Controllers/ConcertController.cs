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
    public class ConcertController : GenericController<Concert>
    {
        private readonly IConcertService _concertService;

        public ConcertController(IConcertService concertService): base(concertService)
        {
            _concertService = concertService;
        }

        //! Para la vista de admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcert()
        {
            try{
                return Ok(await _concertService.Get(
                    includes : c => c.Artist
                ));
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        //! Para la pagina web
        [AllowAnonymous]
        [HttpGet("proximos-conciertos")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertProximosConciertos()
        {
            try{
                return Ok(await _concertService.GetFutureConcerts());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        // TODO change to role crew y probarlo
        [Authorize(Roles = "Admin")]
        [HttpGet("artist-id")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertArtistId(int artistId)
        {
            try{
                return Ok(await _concertService.GetConcertForArtist(artistId));
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }

        }

        // TODO hacer esto para view crew
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcert(int id)
        {         
            return null;
        }

        
    }
}