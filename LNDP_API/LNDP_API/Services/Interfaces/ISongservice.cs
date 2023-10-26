using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface ISongService : IGenericService<Song>
    {
        Task<PagedResponse<List<Song>>> GetSongs([FromQuery] PaginationFilter paginationFilter, string route);
    }
}