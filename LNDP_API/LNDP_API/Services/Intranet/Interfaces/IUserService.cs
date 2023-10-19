using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUser();
        Task<bool> ExistUser(int idUser);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User User);
        Task DeleteUser(int idUser);
    }
}