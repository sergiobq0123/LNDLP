using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IArtistService : IGenericService<Artist>
    {
        Task<IEnumerable<KeysIntranetDto>> GetArtistKeys();
    }
}