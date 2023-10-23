using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class ConcertService : GenericService<Concert>, IConcertService
    {
        private readonly IConcertRepository _concertRepository;

        public ConcertService(IConcertRepository concertRepository, IMapper mapper) : base(concertRepository, mapper)
        {
            _concertRepository = concertRepository;

        }

        public async Task<IEnumerable<Concert>> GetConcerts()
        {
            return await _concertRepository.GetWithIncludesAsync(
             includes: c => c.Artist
            );
        }
        public async Task<IEnumerable<Concert>> GetConcertForArtist(int idArista)
        {
            return await _concertRepository.GetWithIncludesAsync(
             includes: c => c.Artist,
             filter: c => c.Artist.UserId == idArista
            );
        }
        public async Task<IEnumerable<ConcertWebDto>> GetFutureConcerts()
        {
            var conciertos = await _concertRepository.GetFutureConcertsAsync();
            return _mapper.Map<IEnumerable<ConcertWebDto>>(conciertos);
        }

    }
}
