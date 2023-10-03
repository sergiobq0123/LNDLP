using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{
    public interface IArtistService{
        Task<Artist> CreateArtist(ArtistCreateDto artistCreateDto);
    }
}