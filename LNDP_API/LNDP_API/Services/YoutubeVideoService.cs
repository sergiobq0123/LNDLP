using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class YoutubeVideoService : GenericService<YoutubeVideo>, IYoutubeVideoService
    {
        private readonly IYoutubeVideoRepository _youtubeVideoRepository;
        public YoutubeVideoService(IYoutubeVideoRepository youtubeVideoRepository, IMapper mapper, IUriService uriService) : base(youtubeVideoRepository, mapper, uriService)
        {
            _youtubeVideoRepository = youtubeVideoRepository;
        }

        public async Task<IEnumerable<YoutubeVideoWebDto>> GetYoutubeVideoDto()
        {
            var youtubeVideos = await _youtubeVideoRepository.GetAsync(null);
            return _mapper.Map<IEnumerable<YoutubeVideoWebDto>>(youtubeVideos);
        }

    }
}
