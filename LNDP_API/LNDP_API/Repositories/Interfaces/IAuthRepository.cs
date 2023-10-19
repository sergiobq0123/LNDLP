using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IAuthRepository{
       Task<bool> UsernameExistAsync(string username);
       Task<Acces> CreateAsync(Acces acces);
    }
}