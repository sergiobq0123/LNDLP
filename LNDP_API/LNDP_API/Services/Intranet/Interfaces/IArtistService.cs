using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtist();
        Task<IEnumerable<KeysIntranetDto>> GetArtistKeys();
        Task<bool> ExistArtist(int idArtist);
        Task<Artist> CreateArtist(Artist artist);
        Task<Artist> UpdateArtist(Artist artist);
        Task DeleteArtist(int idArtist);
    }
}