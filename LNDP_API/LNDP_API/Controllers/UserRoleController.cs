using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;
using System.Linq.Expressions;
using LNDP_API.Dtos;
using AutoMapper;
using LNDP_API.Services;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : GenericController<UserRole>
    {
        private readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService) : base(userRoleService)
        {
            _userRoleService = userRoleService;
        }
    }
}
