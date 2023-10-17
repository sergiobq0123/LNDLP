using LNDP_API.Data;
using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services
{
    public class FestivalArtistAsocService : IFestivalArtistAsocService
    {
        private readonly APIContext _context;
        public FestivalArtistAsocService(APIContext context)
        {
            _context = context;
        }

        public async Task CreateFestivalWithArtists(FestivalArtistDto festivalArtistDto)
        {
            Festival festival = await _context.Festival.FindAsync(festivalArtistDto.FestivalId);
            if(festival == null){
                throw new Exception("No se ha encontrado ningún festival");
            }
            foreach (var artista in festivalArtistDto.NuevosArtistas){
                    Artist artist = await _context.Artist.FindAsync(artista.Id);
                    ArtistFestivalAsoc artistFestivalAsoc = new ArtistFestivalAsoc {
                        Artist = artist,
                        Festival = festival
                    };
                    _context.ArtistFestivalAsoc.Add(artistFestivalAsoc);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFestivalFromArtist(FestivalArtistDto festivalArtistDto)
        {
            Festival festival = await _context.Festival.FindAsync(festivalArtistDto.FestivalId);
            if(festival == null){
                throw new Exception("No se ha encontrado ningún festival");
            }
                foreach (var artista in festivalArtistDto.ArtistasEliminados){
                    Artist artist = await _context.Artist.FindAsync(artista.Id);
                    ArtistFestivalAsoc artistFestivalAsoc = _context.ArtistFestivalAsoc.FirstOrDefault(a => a.ArtistId == artist.Id && a.FestivalId == festival.Id);
                    _context.Remove(artistFestivalAsoc);
                    await _context.SaveChangesAsync();
                }
        }
        public async Task UpdateFestivalWithArtists(FestivalArtistDto festivalArtistDto)
        {
            await CreateFestivalWithArtists(festivalArtistDto);
            await DeleteFestivalFromArtist(festivalArtistDto);
        }
    }

}
