using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface ICompanyTypeService
    {
        Task<IEnumerable<CompanyType>> GetCompanyType();
    }
}