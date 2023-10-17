using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IFestivalArtistAsocService
    {
        Task CreateFestivalWithArtists(FestivalArtistDto festivalArtistDto);
        Task DeleteFestivalFromArtist(FestivalArtistDto festivalArtistDto);
        Task UpdateFestivalWithArtists(FestivalArtistDto festivalArtistDto);
    }
}