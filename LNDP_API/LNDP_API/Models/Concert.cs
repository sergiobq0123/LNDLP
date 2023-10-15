namespace LNDP_API.Models {
    public class Concert : ModelBase{
        public string? Name {get; set;}
        public string? City {get; set;}
        public string? Location {get; set;}
        public string? UrlLocation {get; set;}
        public string? Tickets {get; set;}
        public DateTime? Date {get; set;}
        public Artist? Artist {get;set;}
        public int? ArtistId {get; set;}
    }
}