namespace LNDP_API.Dtos {
    public class ConcertIntranetDto{
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? City {get; set;}
        public string? Location {get; set;}
        public string? UrlLocation {get; set;}
        public string? Tickets {get; set;}
        public DateTime? Date {get; set;}
        public int? ArtistId {get; set;}
        public string? ArtistName {get; set;}
    }
}