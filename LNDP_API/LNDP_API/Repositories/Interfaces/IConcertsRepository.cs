using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IConcertRepository{
        Task<IEnumerable<Concert>> GetAsync();
        Task<IEnumerable<Concert>> GetConcertsArtistAsync(int idArtista);
        Task<IEnumerable<Concert>> GetFutureConcertsAsync();
        Task<bool> ExistConcertAsync(int idConcert);
        Task<Concert> CreateAsync(Concert concert);
        Task<Concert> UpdateAsync(Concert concert);
        Task DeleteAsync(int idConcert);
    }
}