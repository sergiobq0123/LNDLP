using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IConcertService : IGenericService<Concert>
    {
        Task<IEnumerable<Concert>> GetConcerts();
        Task<IEnumerable<Concert>> GetConcertForArtist(int idArtista);
        Task<IEnumerable<Concert>> GetFutureConcerts();
    }
}