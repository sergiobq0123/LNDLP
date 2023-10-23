using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class FestivalService : GenericService<Festival>, IFestivalService
    {
        private readonly IFestivalRepository _festivalRepository;
        public FestivalService(IFestivalRepository festivalRepository, IMapper mapper) : base(festivalRepository, mapper)
        {
            _festivalRepository = festivalRepository;
        }
        public async Task<IEnumerable<Festival>> GetFestivals()
        {
            return await _festivalRepository.GetFestivalsAsync();
        }
        public async Task<IEnumerable<FestivalWebDto>> GetFutureFestivals()
        {
            var festivales = await _festivalRepository.GetFutureFestivalsAsync();
            return _mapper.Map<IEnumerable<FestivalWebDto>>(festivales);
        }


    }
}
