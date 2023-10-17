namespace LNDP_API.Models {
    public class ArtistFestivalAsoc :ModelBase{
        public Festival Festival {get; set;} = new();
        public Artist Artist {get; set;} = new();
        public int FestivalId {get; set;} = new();
        public int ArtistId {get; set;} = new();

    }
}