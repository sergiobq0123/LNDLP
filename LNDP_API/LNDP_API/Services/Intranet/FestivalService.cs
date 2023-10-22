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
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public FestivalService(IFestivalRepository festivalRepository, IMapper mapper, IImageUtils imageUtils) : base(festivalRepository, imageUtils)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }
        public async Task<IEnumerable<Festival>> GetFestivals()
        {
            return await _festivalRepository.GetFestivalsAsync();
        }

        public async Task<IEnumerable<Festival>> GetFestivalForArtist(int idArista)
        {
           return await _festivalRepository.GetFestivalsForArtistAsync(idArista);
        }
    }
}
