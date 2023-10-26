using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class FestivalService : GenericService<Festival>, IFestivalService
    {
        private readonly IFestivalRepository _festivalRepository;
        public FestivalService(IFestivalRepository festivalRepository, IMapper mapper, IUriService uriService) : base(festivalRepository, mapper, uriService)
        {
            _festivalRepository = festivalRepository;
        }
        public async Task<PagedResponse<List<Festival>>> GetFestivales([FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<Festival> query = await _festivalRepository.GetFestivalesAsync();
            return await this.GetPagination(paginationFilter, query, route);
        }

        public async Task<IEnumerable<FestivalWebDto>> GetFutureFestivals()
        {
            var festivales = await _festivalRepository.GetFutureFestivalsAsync();
            return _mapper.Map<IEnumerable<FestivalWebDto>>(festivales);
        }


    }
}
