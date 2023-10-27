using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using LNDP_API.Dtos;
using LNDP_API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using LNDP_API.Filters;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _userService.GetUsers(paginationFilter, Request.Path.Value, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<User>>> PostFilterUsers([FromQuery] PaginationFilter paginationFilter, [FromBody] List<Filter> filters)
        {
            try
            {
                return Ok(await _userService.GetUsers(paginationFilter, Request.Path.Value, filters));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-register")]
        public async Task<ActionResult<IEnumerable<User>>> PostUser(UserCreateDto userCreateDto)
        {
            try
            {
                await _userService.PostUser(userCreateDto);
                return Ok(new { Message = "Usuario creado(a) con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
