using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface ISongService : IGenericService<Song>
    {
        Task<IEnumerable<SongWebDto>> GetSongDto();
    }
}