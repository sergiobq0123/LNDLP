using System.Linq.Expressions;
using LNDP_API.Data;
using Microsoft.EntityFrameworkCore;

namespace LNDP_API.Repositories{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly APIContext _context;

        public GenericRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Exist(TEntity entity)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Equals(entity));

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

            public async Task<IEnumerable<TEntity>> GetWithIncludesAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>> includes = null)
            {
                var query = _context.Set<TEntity>().AsQueryable();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includes != null)
                {
                    query = query.Include(includes);
                }
                return await query.ToListAsync();
            }
    }
}
