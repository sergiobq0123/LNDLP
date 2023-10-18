using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompany();
        Task<IEnumerable<CompanyWebDto>> GetCompanyType(string type);
        Task<bool> ExistCompany(int idCompany);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task DeleteCompany(int idCompany);
    }
}