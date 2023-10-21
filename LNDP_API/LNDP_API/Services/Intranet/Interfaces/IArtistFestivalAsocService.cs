using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IArtistFestivalAsocService : IGenericService<ArtistFestivalAsoc>
    {
        Task<ArtistFestivalAsoc> CreateArtistFestivalAsoc(ArtistFestivalAsoc ArtistFestivalAsoc);
        Task DeleteArtistFestivalAsoc(int idArtistFestivalAsoc);
        Task UpdateFestivalWithArtists(FestivalArtistDto festivalArtistDto);
    }
}