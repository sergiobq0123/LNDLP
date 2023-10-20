using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class CompanyTypeRepository : ICompanyTypeRepository
    {
        private readonly APIContext _context;
        public CompanyTypeRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CompanyType>> GetAsync()
        {
            return await _context.CompanyType.AsNoTracking().ToListAsync();
        }
    }
}
