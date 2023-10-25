using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly APIContext _context;
        public CompanyRepository(APIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Company>> GetCompaniesAsync()
        {
            var query = _context.Company.Include(c => c.CompanyType).AsNoTracking();
            return await Task.FromResult(query);
        }

        public async Task<IEnumerable<Company>> GetByTypeAsync(string type)
        {
            return await _context.Company.Where(c => c.CompanyType.CompanyTypeName == type).AsNoTracking().ToListAsync();
        }
    }
}
