using System.Linq.Expressions;
using LNDP_API.Filters;
using LNDP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Repositories
{
    public interface IConcertRepository : IGenericRepository<Concert>
    {
        Task<IQueryable<Concert>> GetConcertsAsync(Expression<Func<Concert, bool>> predicate);
        Task<IQueryable<Concert>> GetConcertsForArtistAsync(Expression<Func<Concert, bool>> predicate, int id);
        Task<IEnumerable<Concert>> GetFutureConcertsAsync();
    }
}