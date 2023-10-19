using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{
    public interface IAuthService{
        Task<Acces> Register(AccesDto accesDto);
        Task<bool> ExistUserName(string username);
        Task<string> Login(string email, string password);
        Task<User> UpdateUser(UserIntranetDto userRegistrerDto);
        Task DeleteUser(int idUser);
    }
}