using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;

namespace LNDP_API.Services
{
    public class CompanyTypeService : GenericService<CompanyType>, ICompanyTypeService
    {
        private readonly ICompanyTypeRepository _companyTypeRepository;

        public CompanyTypeService(ICompanyTypeRepository companyTypeRepository, IMapper mapper, IUriService uriService) : base(companyTypeRepository, mapper, uriService)
        {
            _companyTypeRepository = companyTypeRepository;
        }
    }
}
