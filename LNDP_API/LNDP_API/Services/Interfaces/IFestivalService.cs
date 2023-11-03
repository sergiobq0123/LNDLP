using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IFestivalService : IGenericService<Festival>
    {
        Task<PagedResponse<List<Festival>>> GetFestivales([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters);
        Task<IEnumerable<FestivalWebDto>> GetFutureFestivals();
    }
}