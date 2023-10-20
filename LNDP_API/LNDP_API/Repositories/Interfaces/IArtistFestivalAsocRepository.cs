using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IArtistFestivalAsocRepository{
        Task<IEnumerable<ArtistFestivalAsoc>> GetAsync();
        Task<bool> ExistArtistFestivalAsocAsync(int idArtistFestivalAsoc);
        Task<int> GetIdByArtistFestival(int idArtista, int idFestival);
        Task<ArtistFestivalAsoc> CreateAsync(ArtistFestivalAsoc artistFestivalAsoc);
        Task<ArtistFestivalAsoc> UpdateAsync(ArtistFestivalAsoc artistFestivalAsoc);
        Task DeleteAsync(int idArtistFestivalAsoc);
    }
}