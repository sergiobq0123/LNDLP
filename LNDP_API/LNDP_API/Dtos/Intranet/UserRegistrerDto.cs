using LNDP_API.Models;

namespace LNDP_API.Dtos{
    public class UserRegistrerDto{
        public int Id {get; set;}
        public string Email {get; set; }
        public string? Password { get; set; }
        public string Username {get; set; }
        public int UserRoleId {get; set;}
        public string? UserRoleName {get; set;}
    }
}