namespace LNDP_API.Models {
    public class Album : ModelBase{
        public string? Name {get; set;}
        public string? Photo {get; set;}
        public Artist? Artist {get; set;} 
        public int? ArtistId {get; set;} 
    }
}