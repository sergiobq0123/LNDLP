using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IUserRepository{
        Task<IEnumerable<User>> GetAsync();
        Task<bool> ExistUserAsync(int idUser);
        Task<bool> ExistUserMailAsync(string userName);
        Task<User> CreateAsync(User User);
        Task<User> UpdateAsync(User User);
        Task DeleteAsync(int idUser);
    }
}