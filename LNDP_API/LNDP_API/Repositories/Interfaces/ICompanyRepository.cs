using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IQueryable<Company>> GetCompaniesAsync();
        Task<IEnumerable<Company>> GetByTypeAsync(string type);
    }
}