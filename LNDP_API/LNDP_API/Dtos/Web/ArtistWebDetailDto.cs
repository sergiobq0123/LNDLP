namespace LNDP_API.Dtos {
    public class ArtistWebDetailDto{
        public string? Name {get;set;}
        public string? Description {get;set;}
        public string? PhotoUrl {get;set;}
        public ICollection<GenericCardDto>? Albums {get;set;}
        public ICollection<SongWebDto>? Songs {get;set;}
        public ICollection<EventWebDto>? Events {get;set;}
    }
}