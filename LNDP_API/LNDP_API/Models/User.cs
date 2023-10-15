using System;

namespace LNDP_API.Models{
    public class User : ModelBase{
        
        public string Username {get; set; }
        public string Email {get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public string PasswordHash {get; set; }
        public string PasswordSalt {get; set; }
    }
}