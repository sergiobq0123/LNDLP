using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IArtistFestivalAsocRepository : IGenericRepository<ArtistFestivalAsoc>
    {
        Task<bool> ExistArtistFestivalAsocAsync(int idArtistFestivalAsoc);
        Task<int> GetIdByArtistFestival(int idArtista, int idFestival);
        Task<IQueryable<ArtistFestivalAsoc>> GetFestivalsForArtistAsync(int id, Expression<Func<ArtistFestivalAsoc, bool>> predicate);
    }
}