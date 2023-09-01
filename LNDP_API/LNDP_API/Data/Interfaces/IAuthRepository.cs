using LNDP_API.Models;

namespace LNDP_API.Data.Interfaces {
    public interface IAuthRepository{

        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> ExistUser(string correo);
    }
}