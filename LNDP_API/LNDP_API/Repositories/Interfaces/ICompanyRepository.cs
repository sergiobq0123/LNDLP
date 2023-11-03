using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IQueryable<Company>> GetCompaniesAsync(Expression<Func<Company, bool>> predicate);
        Task<IEnumerable<Company>> GetByTypeAsync(string type);
    }
}