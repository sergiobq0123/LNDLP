using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IArtistService : IGenericService<Artist>
    {
        Task<IEnumerable<Artist>> GetArtists();
        Task<IEnumerable<KeysIntranetDto>> GetArtistKeys();
        Task<Artist> PostArtist(ArtistCreateDto artistCreateDto);
        
    }
}