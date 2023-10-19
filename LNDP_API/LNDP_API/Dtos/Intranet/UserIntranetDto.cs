using LNDP_API.Models;

namespace LNDP_API.Dtos{
    public class UserIntranetDto{

        public string Name {get; set; }
        public string Surname {get; set; }
        public string Email {get; set; }
        public int UserRoleId {get; set;}
        public string Username {get; set; }
        public string? Password { get; set; }
        
    }
}