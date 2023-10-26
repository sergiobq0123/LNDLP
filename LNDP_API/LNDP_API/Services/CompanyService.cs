using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IUriService uriService) : base(companyRepository, mapper, uriService)
        {
            _companyRepository = companyRepository;
        }

        public async Task<PagedResponse<List<Company>>> GetCompanies([FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<Company> query = await _companyRepository.GetCompaniesAsync();
            return await this.GetPagination(paginationFilter, query, route);
        }

        public async Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type)
        {
            var Companys = await _companyRepository.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<CompanyWebDto>>(Companys);
        }
    }
}
