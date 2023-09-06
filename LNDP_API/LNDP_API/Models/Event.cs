namespace LNDP_API.Models {
    public class Event : ModelBase{
        public string? Name {get; set;}
        public string? Location {get; set;}
        public string? UrlLocation {get; set;}
        public string? City {get; set;}
        public string? Tickets {get; set;}
    }
}