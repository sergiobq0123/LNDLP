using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IAccesService : IGenericService<Acces>
    {
        Task<Acces> Register(AccesDto accesDto);
        Task<string> Login(AccesDto accesDto);
    }
}