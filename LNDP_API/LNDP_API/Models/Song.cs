using LNDP_API.Models.Interfaces;

namespace LNDP_API.Models {
    public class Song : ModelBase, IHasUrl{
        public string Name {get; set;}
        public string Url {get; set;}
        public Artist? Artist {get; set;} 
        public int ArtistId {get; set;} 
    }
}