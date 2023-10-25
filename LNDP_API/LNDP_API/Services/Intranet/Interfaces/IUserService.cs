using LNDP_API.Dtos;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<PagedResponse<List<User>>> GetUsers([FromQuery] PaginationFilter paginationFilter, string route);
        Task<User> PostUser(UserCreateDto userCreateDto);
    }
}