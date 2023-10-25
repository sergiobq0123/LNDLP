using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class ConcertService : GenericService<Concert>, IConcertService
    {
        private readonly IConcertRepository _concertRepository;

        public ConcertService(IConcertRepository concertRepository, IMapper mapper, IUriService uriService) : base(concertRepository, mapper, uriService)
        {
            _concertRepository = concertRepository;

        }

        public async Task<PagedResponse<List<Concert>>> GetConcerts([FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<Concert> query = await _concertRepository.GetConcertsAsync();
            return await this.GetPagination(paginationFilter, query, route);
        }
        public async Task<PagedResponse<List<Concert>>> GetConcertsForArtist(int id, [FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<Concert> query = await _concertRepository.GetConcertsForArtistAsync(id);
            return await this.GetPagination(paginationFilter, query, route);
        }
        public async Task<IEnumerable<ConcertWebDto>> GetFutureConcerts()
        {
            var conciertos = await _concertRepository.GetFutureConcertsAsync();
            return _mapper.Map<IEnumerable<ConcertWebDto>>(conciertos);
        }

    }
}
