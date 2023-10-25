using LNDP_API.Dtos;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IArtistService : IGenericService<Artist>
    {
        Task<PagedResponse<List<Artist>>> GetArtistas([FromQuery] PaginationFilter paginationFilter, string route);
        Task<IEnumerable<ArtistWebGenericDto>> GetArtistsWeb();
        Task<Artist> PostArtist(ArtistCreateDto artistCreateDto);
        Task<ArtistWebDetailDto> GetArtistById(int id);

    }
}