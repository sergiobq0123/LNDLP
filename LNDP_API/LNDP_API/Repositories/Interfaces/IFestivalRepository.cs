using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IFestivalRepository{
        Task<IEnumerable<Festival>> GetAsync();
        Task<bool> ExistFestivalAsync(int idFestival);
        Task<Festival> CreateAsync(Festival festival);
        Task<Festival> UpdateAsync(Festival festival);
        Task DeleteAsync(int idFestival);
    }
}