using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IFestivalService : IGenericService<Festival>
    {
        Task<IEnumerable<Festival>> GetFestivalForArtist(int idArtista);
        Task<IEnumerable<Festival>> GetFestivals();
    }
}