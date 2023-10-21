using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : GenericController<Festival>
    {
        private readonly IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService): base(festivalService)
        {
            _festivalService = festivalService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivalIntranet()
        {
            try{
                return Ok(await _festivalService.Get());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}