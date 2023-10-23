using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IArtistService : IGenericService<Artist>
    {
        Task<IEnumerable<Artist>> GetArtists();
        Task<IEnumerable<ArtistWebGenericDto>> GetArtistsWeb();
        Task<Artist> PostArtist(ArtistCreateDto artistCreateDto);
        Task<ArtistWebDetailDto> GetArtistById(int id);

    }
}