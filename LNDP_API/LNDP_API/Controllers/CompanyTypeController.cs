using LNDP_API.Dtos;
using LNDP_API.Services;
using LNDP_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : GenericController<CompanyType>
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeController(ICompanyTypeService companyTypeService) : base(companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
    }
}