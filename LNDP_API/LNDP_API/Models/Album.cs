using LNDP_API.Models.Interfaces;

namespace LNDP_API.Models
{
    public class Album : ModelBase, IHasPhotoUrl
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string WebUrl { get; set; }
        public DateTime Date { get; set; }
        public Artist? Artist { get; set; }
        public int ArtistId { get; set; }
    }
}