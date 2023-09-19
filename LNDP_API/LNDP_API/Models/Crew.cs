namespace LNDP_API.Models {
    public class Crew {
        public int Id {get; set;}
        public Artist Artist {get; set;} 
        public string? Dj {get; set;}
        public string? RoadManager {get;set;}
        public string? SoundTechnician {get;set;}
        public string? LightingTechnician {get;set;}
    }
}