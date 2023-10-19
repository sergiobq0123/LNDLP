using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IFestivalService
    {
        Task<IEnumerable<Festival>> GetFestival();
        Task<bool> ExistFestival(int idFestival);
        Task<Festival> CreateFestival(Festival festival);
        Task<Festival> UpdateFestival(Festival festival);
        Task DeleteFestival(int idFestival);
    }
}