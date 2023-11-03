using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IFestivalRepository : IGenericRepository<Festival>
    {
        Task<IQueryable<Festival>> GetFestivalesAsync();
        Task<IEnumerable<Festival>> GetFutureFestivalsAsync();
    }
}