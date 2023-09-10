using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LNDP_API.Models {
    public class Artist : ModelBase {
        public string? Name {get ; set ; }
        public string? City {get ; set ; }
        public Photo? Photo {get ; set ; }
        public string? RecruitmentEmail {get ; set ; }
        public string? CommunicationEmail {get ; set ; }
        public  string? Phone {get ; set ; }
        public int? UserId {get; set;}
        public User? User {get; set;}
        public int? CrewId {get; set;}
        public Crew? Crew {get; set;}
        public int? SocialNetworkId {get; set;}
        public SocialNetwork? SocialNetwork {get; set;}
        public ICollection<Event>? Events {get; set;} 

    }
}