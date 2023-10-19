using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly APIContext _context;
        public CompanyRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _context.Company.Include(c => c.CompanyType).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Company>> GetByTypeAsync(string type)
        {
            return await _context.Company.Where(c => c.CompanyType.CompanyTypeName == type).AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistCompanyAsync(int idCompany)
        {
            return await _context.Company.AnyAsync(v => v.Id == idCompany);
        }

        public async Task<Company> CreateAsync(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task DeleteAsync(int idCompany)
        {
            _context.Company.Remove(await _context.Company.FindAsync(idCompany));
            await _context.SaveChangesAsync();
        }
    }
}
