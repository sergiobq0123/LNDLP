namespace LNDP_API.Dtos {
    public class ArtistGetDto{

        public int Id {get ; set ; }
        public string Name {get ; set ; }
        public string? City {get ; set ; }
        public string ? PhotoUrl {get ; set ; }
        public string? RecruitmentEmail {get ; set ; }
        public string? CommunicationEmail {get ; set ; }
        public  string? Phone {get ; set ; }
        public SocialNetworkIntranetDto socialNetworkIntranetDto {get; set;}
        public CrewIntranetDto crewIntranetDto {get; set;}
    }
}