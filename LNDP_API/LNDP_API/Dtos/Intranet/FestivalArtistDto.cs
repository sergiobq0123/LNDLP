namespace LNDP_API.Dtos
{
    public class FestivalArtistDto
    {

        public int FestivalId { get; set; }
        public ICollection<KeysIntranetDto> NuevosArtistas { get; set; }
        public ICollection<KeysIntranetDto> ArtistasEliminados { get; set; }
    }
}