using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> ExistUserAsync(int idUser);
        Task<bool> ExistUserMailAsync(string userName);
        Task<IQueryable<User>> GetUsersAsync();
    }
}