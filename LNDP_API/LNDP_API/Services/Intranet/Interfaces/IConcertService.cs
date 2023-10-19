using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IConcertService
    {
        Task<IEnumerable<Concert>> GetConcert();
        Task<IEnumerable<Concert>> GetConcertForArtist(int idArtista);
        Task<IEnumerable<Concert>> GetFutureConcerts();
        Task<bool> ExistConcert(int idConcert);
        Task<Concert> CreateConcert(Concert concert);
        Task<Concert> UpdateConcert(Concert concert);
        Task DeleteConcert(int idConcert);
    }
}