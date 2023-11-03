using System.Linq.Expressions;
using LNDP_API.Data;
using LNDP_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LNDP_API.Repositories
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly APIContext _context;

        public GenericRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            var query = _context.Set<TEntity>().AsNoTracking();
            return await Task.FromResult(query);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Set<TEntity>().Remove(await _context.Set<TEntity>().FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
