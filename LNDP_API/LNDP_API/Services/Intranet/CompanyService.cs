using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public CompanyService(ICompanyRepository CompanyRepository, IMapper mapper, IImageUtils imageUtils)
        {
            _companyRepository = CompanyRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<Company>> GetCompany()
        {
            return await _companyRepository.GetAsync();
        }

        public async Task<IEnumerable<CompanyWebDto>> GetCompanyType(string type)
        {
            var Companys = await _companyRepository.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<CompanyWebDto>>(Companys);
        }

        public async Task<Company> CreateCompany(Company company)
        {
            company.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(company.PhotoUrl, company.Name);
            return await _companyRepository.CreateAsync(company);
        }
        
        public async Task<bool> ExistCompany(int idCompany)
        {
            return await _companyRepository.ExistCompanyAsync(idCompany);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            if(!_imageUtils.IsValidUrl(company.PhotoUrl)){
                company.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(company.PhotoUrl, company.Name);
            }
            return await _companyRepository.UpdateAsync(company);
        }

        public async Task DeleteCompany(int idCompany)
        {
            await _companyRepository.DeleteAsync(idCompany);
        }
        

    }
}
