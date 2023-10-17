using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LNDP_API.Models {
    public class Artist : ModelBase {
        public string? Name {get ; set ; }
        public string? Description {get ; set ; }
        public string? City {get ; set ; }
        public string ? PhotoUrl {get ; set ; }
        public string? RecruitmentEmail {get ; set ; }
        public string? CommunicationEmail {get ; set ; }
        public  string? Phone {get ; set ; }
        public SocialNetwork? SocialNetwork { get; set; }
        public User? User { get; set; }
        public ICollection<Album>? Albums {get; set;} 
        public ICollection<Song>? Songs {get; set;} 
        public ICollection<Concert>? Concerts {get; set;} 
        public ICollection<ArtistFestivalAsoc>? ArtistFestivalAsoc {get; set;} 
    }
}