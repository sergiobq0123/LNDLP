using Microsoft.AspNetCore.Mvc;
using LNDP_API.Models;
using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesController : ControllerBase
    {
        private readonly IAccesService _accesService;

        public AccesController(IAccesService accesService)
        {
            _accesService = accesService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public virtual async Task<ActionResult<string>> Login(AccesDto accesDto)
        {
            try
            {
                string token = await _accesService.Login(accesDto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<string>> ChangePassword(int id, AccesDto accesDto)
        {
            try
            {
                await _accesService.ChangePassword(id, accesDto.Password);
                return Ok(new { Message = $"Contraseña actualizada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}