namespace LNDP_API.Models {
    public class Festival : ModelBase{
        public string? Name {get; set;}
        public string? City {get; set;}
        public string? Location {get; set;}
        public string? UrlLocation {get; set;}
        public string? Tickets {get; set;}
        public DateTime? Date {get; set;}
        public ICollection<ArtistFestivalAsoc>? ArtistFestivalAsoc {get;set;}
    }
}