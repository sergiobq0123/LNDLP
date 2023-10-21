using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IFestivalRepository : IGenericRepository<Festival>{
        Task<IEnumerable<Festival>> GetWithRelationAsync();
        Task<bool> ExistFestivalAsync(int idFestival);
    }
}