namespace LNDP_API.Dtos {
    public class FestivalArtistDto{

        public int FestivalId {get ; set ; }
        public ICollection<ArtistGetDto> NuevosArtistas {get; set;}
        public ICollection<ArtistGetDto> ArtistasEliminados {get; set;}
    }
}