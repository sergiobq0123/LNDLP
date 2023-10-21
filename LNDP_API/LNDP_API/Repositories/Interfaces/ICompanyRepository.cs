using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface ICompanyRepository : IGenericRepository<Company>{
        Task<IEnumerable<Company>> GetByTypeAsync(string type);
    }
}