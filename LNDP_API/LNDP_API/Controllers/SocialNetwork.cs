using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;
using LNDP_API.Repositories;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : ControllerBase
    {
        private readonly ISocialNetworkService _socialNetworkService;

        public SocialNetworkController(ISocialNetworkService socialNetworkService)
        {
            _socialNetworkService = socialNetworkService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSocialNetwork(int id, SocialNetwork socialNetwork)
        {
            await _socialNetworkService.Update(socialNetwork);
            return Ok(new { Message = "Red social actualizada con exito" });
        }

    }
}