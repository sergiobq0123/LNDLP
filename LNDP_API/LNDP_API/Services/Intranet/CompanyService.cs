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
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IImageUtils imageUtils): base(companyRepository, imageUtils)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<CompanyWebDto>> GetCompaniesByType(string type)
        {
            var Companys = await _companyRepository.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<CompanyWebDto>>(Companys);
        }
    }
}
