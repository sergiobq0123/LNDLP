using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using TTTAPI.JWT.Managers;
using Microsoft.AspNetCore.Authorization;
using LNDP_API.Filters;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : GenericController<Concert>
    {
        private readonly IConcertService _concertService;

        public ConcertController(IConcertService concertService) : base(concertService)
        {
            _concertService = concertService;
        }

        //! Para la vista de admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcert([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _concertService.GetConcerts(paginationFilter, Request.Path.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("proximos-conciertos")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertProximosConciertos()
        {
            try
            {
                return Ok(await _concertService.GetFutureConcerts());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize(Roles = "Crew")]
        [HttpGet("concert-user-id/{id}")]
        public async Task<ActionResult> GetConcertforArtist(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _concertService.GetConcertsForArtist(id, paginationFilter, Request.Path.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}