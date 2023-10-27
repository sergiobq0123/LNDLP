using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<PagedResponse<List<Company>>> GetCompanies([FromQuery] PaginationFilter paginationFilter, string route, [FromBody] List<Filter> filters);
        Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type);
    }
}