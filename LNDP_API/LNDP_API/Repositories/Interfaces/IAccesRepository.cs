using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IAccesRepository : IGenericRepository<Acces>
    {
        Task<bool> UsernameExistAsync(string username);
        Task<Acces> LoginAsync(string username);
    }
}