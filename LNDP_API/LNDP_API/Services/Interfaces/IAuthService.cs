using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{
    public interface IAuthService{
        Task<User> Register(UserRegistrerDto userDto);
        Task<User> Update(UserRegistrerDto userDto);
        Task<string> Login(string email, string password);
    }
}