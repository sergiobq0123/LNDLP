namespace LNDP_API.Dtos {
    public class UserLisDto{
        public int Id {get ; set ; }
        public string Username {get; set; }
        public string Email {get; set; }
        public string Token {get; set;}
        public DateTime CreationDate  {get; set; } 
        public bool IsActive {get;set; }
    }
}