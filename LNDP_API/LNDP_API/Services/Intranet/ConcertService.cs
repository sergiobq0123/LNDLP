using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IMapper _mapper;
        public ConcertService(IConcertRepository concertRepository, IMapper mapper)
        {
            _concertRepository = concertRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Concert>> GetConcert()
        {
            return await _concertRepository.GetAsync();
        }

        public async Task<Concert> CreateConcert(Concert concert)
        {
            return await _concertRepository.CreateAsync(concert);
        }
        public async Task<IEnumerable<Concert>> GetConcertForArtist(int idArista)
        {
           return await _concertRepository.GetConcertsArtistAsync(idArista);
        }
        public async Task<IEnumerable<Concert>> GetFutureConcerts()
        {
           return await _concertRepository.GetFutureConcertsAsync();
        }
        
        public async Task<bool> ExistConcert(int idConcert)
        {
            return await _concertRepository.ExistConcertAsync(idConcert);
        }

        public async Task<Concert> UpdateConcert(Concert concert)
        {
            return await _concertRepository.UpdateAsync(concert);
        }

        public async Task DeleteConcert(int idConcert)
        {
            await _concertRepository.DeleteAsync(idConcert);
        }
        

    }
}
