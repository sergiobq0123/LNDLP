namespace LNDP_API.Models {
    public class Photo : ModelBase{
        public string? Name {get; set;}
        public string? Description {get; set;}
        public byte[]? Imagen {get; set;}
    }
}