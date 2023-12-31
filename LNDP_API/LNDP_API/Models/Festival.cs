using LNDP_API.Models.Interfaces;

namespace LNDP_API.Models
{
    public class Festival : ModelBase, IHasPhotoUrl
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Tickets { get; set; }
        public DateTime Date { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<ArtistFestivalAsoc>? ArtistFestivalAsoc { get; set; }
    }
}