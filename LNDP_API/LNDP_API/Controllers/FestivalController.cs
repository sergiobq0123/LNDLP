using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService)
        {
            _festivalService = festivalService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivalIntranet()
        {
            try{
                return Ok(await _festivalService.GetFestival());
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> PostFestival(Festival festival)
        {
            try{
                Festival f = await _festivalService.CreateFestival(festival);
                return Ok(new { Message = "Festival creada con éxito", f});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutFestival(int id, Festival festival)
        {
            if (!await _festivalService.ExistFestival(id))
            {
                return BadRequest(new { Message = "El festival especificada no existe."});
            }
            try{
                Festival f = await _festivalService.UpdateFestival(festival);
                return Ok(new { Message = "Festival actualizado con éxito.", f});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            if (!await _festivalService.ExistFestival(id))
            {
                return BadRequest(new { Message = "El festival especificado no existe." });
            }
            try{
                await _festivalService.DeleteFestival(id);
                return Ok(new { Message = "Festival eliminado con éxito."});
            }
            catch(Exception ex){
                return BadRequest(new {ex.Message});
            }
        }
    }
}