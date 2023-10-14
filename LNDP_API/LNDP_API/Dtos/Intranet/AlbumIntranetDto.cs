namespace LNDP_API.Dtos {
    public class AlbumIntranetDto{
        public int Id {get; set;}
        public string Name {get; set;}
        public string PhotoUrl {get; set;}
        public string WebUrl {get; set;}
        public DateTime Date {get; set;}
        public int ArtistId {get; set;} 
        public string? ArtistName {get; set;}
    }
}