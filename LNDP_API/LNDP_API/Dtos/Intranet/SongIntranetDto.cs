namespace LNDP_API.Dtos {
    public class SongIntranetDto{
        public int Id {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public int ArtistId {get; set;} 
        public string? ArtistName {get; set;} 
    }
}