using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class YoutubeVideoRepository : IYoutubeVideoRepository
    {
        private readonly APIContext _context;
        public YoutubeVideoRepository(APIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<YoutubeVideo>> GetAsync()
        {
            return await _context.YoutubeVideo.AsNoTracking().ToListAsync();
        }
        
        public async Task<bool> ExistYoutubeVideoAsync(int idYoutubeVideo)
        {
            return await _context.YoutubeVideo.AnyAsync(v => v.Id == idYoutubeVideo);
        }

        public async Task<YoutubeVideo> CreateAsync(YoutubeVideo youtubeVideo)
        {
            _context.YoutubeVideo.Add(youtubeVideo);
            await _context.SaveChangesAsync();
            return youtubeVideo;
        }
        public async Task<YoutubeVideo> UpdateAsync(YoutubeVideo youtubeVideo)
        {
            _context.YoutubeVideo.Update(youtubeVideo);
            await _context.SaveChangesAsync();
            return youtubeVideo;
        }
        public async Task DeleteAsync(int idYoutubeVideo)
        {
            _context.YoutubeVideo.Remove(await _context.YoutubeVideo.FindAsync(idYoutubeVideo));
            await _context.SaveChangesAsync();
        }
    }
}
