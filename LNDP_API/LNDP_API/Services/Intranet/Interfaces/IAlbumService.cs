using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbum();
        Task<bool> ExistAlbum(int idAlbum);
        Task<Album> CreateAlbum(Album album);
        Task<Album> UpdateAlbum(Album album);
        Task DeleteAlbum(int idAlbum);
    }
}