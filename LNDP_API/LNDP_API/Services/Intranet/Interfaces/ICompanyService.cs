using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type);

    }
}