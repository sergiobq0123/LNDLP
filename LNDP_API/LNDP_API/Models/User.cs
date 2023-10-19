using System;

namespace LNDP_API.Models{
    public class User : ModelBase{
        
        public string Name {get; set; }
        public string Surname {get; set; }
        public string Email {get; set; }
        public int UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }
        public Acces? Acces { get; set; }
    }
}