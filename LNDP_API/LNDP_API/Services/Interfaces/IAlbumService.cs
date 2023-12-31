using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IAlbumService : IGenericService<Album>
    {
        Task<PagedResponse<List<Album>>> GetAlbums([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters);
    }
}