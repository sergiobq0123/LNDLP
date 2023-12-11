using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IFestivalRepository : IGenericRepository<Festival>
    {
        Task<IQueryable<Festival>> GetFestivalesAsync(Expression<Func<Festival, bool>> predicate);
        Task<IEnumerable<Festival>> GetFutureFestivalsAsync();
    }
}