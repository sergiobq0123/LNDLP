using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IConcertService : IGenericService<Concert>
    {
        Task<PagedResponse<List<Concert>>> GetConcerts([FromQuery] PaginationFilter paginationFilter, string route);
        Task<PagedResponse<List<Concert>>> GetConcertsForArtist(int id, [FromQuery] PaginationFilter paginationFilter, string route);
        Task<IEnumerable<ConcertWebDto>> GetFutureConcerts();
    }
}