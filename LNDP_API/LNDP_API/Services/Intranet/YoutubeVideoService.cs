using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class YoutubeVideoService :GenericService<YoutubeVideo>, IYoutubeVideoService
    {
        private readonly IUrlEmbedUtils _urlEmbedUtils;
        private readonly IYoutubeVideoRepository _youtubeVideoRepository;
        private readonly IMapper _mapper;
        public YoutubeVideoService(IUrlEmbedUtils urlEmbedUtils, IYoutubeVideoRepository youtubeVideoRepository, IMapper mapper): base(youtubeVideoRepository, null, urlEmbedUtils)
        {
            _urlEmbedUtils = urlEmbedUtils;
            _youtubeVideoRepository = youtubeVideoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<YoutubeVideoWebDto>> GetYoutubeVideoDto()
        {
            var youtubeVideos = await _youtubeVideoRepository.GetAsync();
            return _mapper.Map<IEnumerable<YoutubeVideoWebDto>>(youtubeVideos);
        }

    }
}
