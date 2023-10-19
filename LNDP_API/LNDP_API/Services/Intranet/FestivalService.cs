using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;
        private readonly IImageUtils _imageUtils;
        public FestivalService(IFestivalRepository festivalRepository, IMapper mapper, IImageUtils imageUtils)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
            _imageUtils = imageUtils;
        }

        public async Task<IEnumerable<Festival>> GetFestival()
        {
            return await _festivalRepository.GetAsync();
        }


        public async Task<Festival> CreateFestival(Festival festival)
        {
            festival.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(festival.PhotoUrl, festival.Name);
            return await _festivalRepository.CreateAsync(festival);
        }
        
        public async Task<bool> ExistFestival(int idFestival)
        {
            return await _festivalRepository.ExistFestivalAsync(idFestival);
        }

        public async Task<Festival> UpdateFestival(Festival festival)
        {
            if(!_imageUtils.IsValidUrl(festival.PhotoUrl)){
                festival.PhotoUrl = await _imageUtils.ConvertBase64ToUrl(festival.PhotoUrl, festival.Name);
            }
            return await _festivalRepository.UpdateAsync(festival);
        }

        public async Task DeleteFestival(int idFestival)
        {
            await _festivalRepository.DeleteAsync(idFestival);
        }
        

    }
}
