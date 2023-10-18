using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IYoutubeVideoService
    {
        Task<IEnumerable<YoutubeVideo>> GetYoutubeVideo();
        Task<IEnumerable<YoutubeVideoWebDto>> GetYoutubeVideoDto();
        Task<bool> ExistYoutubeVideo(int idYoutubeVideo);
        Task<YoutubeVideo> CreateYotubeVideo(YoutubeVideo youtubeVideo);
        Task<YoutubeVideo> UpdateYoutubeVideo(YoutubeVideo youtubeVideo);
        Task DeleteYoutubeVideo(int idYoutubeVideo);
    }
}