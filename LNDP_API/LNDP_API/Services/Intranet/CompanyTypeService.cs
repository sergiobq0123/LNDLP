using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;

namespace LNDP_API.Services
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly ICompanyTypeRepository _companyTypeRepository;

        public CompanyTypeService(ICompanyTypeRepository companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }

        public async Task<IEnumerable<CompanyType>> GetCompanyType()
        {
            return await _companyTypeRepository.GetAsync();
        }

    }
}
