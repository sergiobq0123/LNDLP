using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class CompanyTypeRepository : GenericRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly APIContext _context;
        public CompanyTypeRepository(APIContext context) : base(context)
        {
            _context = context;
        }
    }
}
