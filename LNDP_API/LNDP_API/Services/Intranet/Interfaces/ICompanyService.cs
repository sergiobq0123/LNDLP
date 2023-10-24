using LNDP_API.Dtos;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<PagedResponse<List<Company>>> GetCompanies([FromQuery] PaginationFilter paginationFilter, string route);
        Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type);
    }
}