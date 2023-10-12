namespace LNDP_API.Dtos {
    public class CompanyIntranetDto{
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public string? PhotoUrl {get; set;}
        public string? WebUrl {get; set;}
        public int? CompanyTypeId {get; set;}
    }
}