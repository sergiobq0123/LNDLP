using LNDP_API.Models;

namespace LNDP_API.Repositories{
    public interface IYoutubeVideoRepository{
        Task<IEnumerable<YoutubeVideo>> GetAsync();
        Task<bool> ExistYoutubeVideoAsync(int idYoutubeVideo);
        Task<YoutubeVideo> CreateAsync(YoutubeVideo youtubeVideo);
        Task<YoutubeVideo> UpdateAsync(YoutubeVideo youtubeVideo);
        Task DeleteAsync(int idYoutubeVideo);
    }
}