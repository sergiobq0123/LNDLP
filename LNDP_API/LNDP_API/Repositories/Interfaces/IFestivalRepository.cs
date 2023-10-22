using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IFestivalRepository : IGenericRepository<Festival>{
        Task<IEnumerable<Festival>> GetFestivalsAsync();
        Task<IEnumerable<Festival>> GetFestivalsForArtistAsync(int artistId);
    }
}