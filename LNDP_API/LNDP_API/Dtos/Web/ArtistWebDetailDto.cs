using LNDP_API.Models;

namespace LNDP_API.Dtos {
    public class ArtistWebDetailDto{
        public string? Name {get;set;}
        public string? Description {get;set;}
        public string? PhotoUrl {get;set;}
        public ICollection<AlbumWebDto>? Albums {get;set;}
        public ICollection<SongWebDto>? Songs {get;set;}
        public ICollection<ConcertWebDto>? Concerts {get;set;}
    }
}