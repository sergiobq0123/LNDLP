using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LNDP_API.Models {
    public class Artist : ModelBase {
        public string? Name {get ; set ; }
        public string? City {get ; set ; }
        public string ? Photo {get ; set ; }
        public string? RecruitmentEmail {get ; set ; }
        public string? CommunicationEmail {get ; set ; }
        public  string? Phone {get ; set ; }
        public Crew? Crew { get; set; }
        public SocialNetwork? SocialNetwork { get; set; }
        public int? UserId { get; set; }
        public ICollection<Event>? Events {get; set;} 
    }
}