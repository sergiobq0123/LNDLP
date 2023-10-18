using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface ICompanyRepository{
        Task<IEnumerable<Company>> GetAsync();
        Task<IEnumerable<Company>> GetByTypeAsync(string type);
        Task<bool> ExistCompanyAsync(int idCompany);
        Task<Company> CreateAsync(Company company);
        Task<Company> UpdateAsync(Company company);
        Task DeleteAsync(int idCompany);
    }
}