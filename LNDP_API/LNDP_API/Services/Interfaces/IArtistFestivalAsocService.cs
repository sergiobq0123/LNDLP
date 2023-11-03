using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IArtistFestivalAsocService : IGenericService<ArtistFestivalAsoc>
    {
        Task<ArtistFestivalAsoc> CreateArtistFestivalAsoc(ArtistFestivalAsoc ArtistFestivalAsoc);
        Task DeleteArtistFestivalAsoc(int idArtistFestivalAsoc);
        Task UpdateFestivalWithArtists(FestivalArtistDto festivalArtistDto);
        Task<PagedResponse<List<ArtistFestivalAsoc>>> GetFestivalForArtist(int id, [FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters);
    }
}