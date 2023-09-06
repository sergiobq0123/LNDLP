using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LNDP_API.Models {
    public class Artist : ModelBase {
        public string? Name {get ; set ; }
        public string? City {get ; set ; }
        public Photo? Photo {get ; set ; }
        public string? RecruitmentEmail {get ; set ; }
        [DataType(DataType.EmailAddress)] [EmailAddress]
        [Display(Name = "Eres tonto")]
        public string? CommunicationEmail {get ; set ; }
        public  string? Phone {get ; set ; }
        public User? IdUser {get; set;}
        public Crew? IdCrew {get; set;}

        public ICollection<Festival>? Festivals {get; set;} 
        public ICollection<Concert>? Concerts {get; set;} 

    }
}