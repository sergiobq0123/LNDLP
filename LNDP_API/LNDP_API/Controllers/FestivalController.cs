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
    public class FestivalController : GenericController<Festival>
    {
        private readonly IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService) : base(festivalService)
        {
            _festivalService = festivalService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivalIntranet([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _festivalService.GetFestivales(paginationFilter, Request.Path.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("proximos-festivales")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertProximosFestivales()
        {
            try
            {
                return Ok(await _festivalService.GetFutureFestivals());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}