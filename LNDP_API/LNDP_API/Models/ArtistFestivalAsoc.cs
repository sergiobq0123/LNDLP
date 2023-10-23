namespace LNDP_API.Models
{
    public class ArtistFestivalAsoc : ModelBase
    {
        public Festival? Festival { get; set; }
        public Artist? Artist { get; set; }
        public int FestivalId { get; set; }
        public int ArtistId { get; set; }
    }
}