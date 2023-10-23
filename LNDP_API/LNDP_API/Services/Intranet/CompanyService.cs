using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper) : base(companyRepository, mapper)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type)
        {
            var Companys = await _companyRepository.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<CompanyWebDto>>(Companys);
        }
    }
}
