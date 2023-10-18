using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class YoutubeVideoService : IYoutubeVideoService
    {
        private readonly IUrlEmbedUtils _urlEmbedUtils;
        private readonly IYoutubeVideoRepository _youtubeVideoRepository;
        private readonly IMapper _mapper;
        public YoutubeVideoService(IUrlEmbedUtils urlEmbedUtils, IYoutubeVideoRepository youtubeVideoRepository, IMapper mapper)
        {
            _urlEmbedUtils = urlEmbedUtils;
            _youtubeVideoRepository = youtubeVideoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<YoutubeVideo>> GetYoutubeVideo()
        {
            return await _youtubeVideoRepository.GetAsync();
        }

        public async Task<IEnumerable<YoutubeVideoWebDto>> GetYoutubeVideoDto()
        {
            var youtubeVideos = await _youtubeVideoRepository.GetAsync();
            return _mapper.Map<IEnumerable<YoutubeVideoWebDto>>(youtubeVideos);
        }

        public async Task<YoutubeVideo> CreateYotubeVideo(YoutubeVideo youtubeVideo)
        {
            youtubeVideo.Url = _urlEmbedUtils.GetEmbedUrlYoutube(youtubeVideo.Url);
            return await _youtubeVideoRepository.CreateAsync(youtubeVideo);
        }
        
        public async Task<bool> ExistYoutubeVideo(int idYoutubeVideo)
        {
            return await _youtubeVideoRepository.ExistYoutubeVideoAsync(idYoutubeVideo);
        }

        public async Task<YoutubeVideo> UpdateYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            youtubeVideo.Url = _urlEmbedUtils.GetEmbedUrlYoutube(youtubeVideo.Url);
            return await _youtubeVideoRepository.UpdateAsync(youtubeVideo);
        }

        public async Task DeleteYoutubeVideo(int idYoutubeVideo)
        {
            await _youtubeVideoRepository.DeleteAsync(idYoutubeVideo);
        }
        

    }
}
