using System;

namespace LNDP_API.Models{
    public class User : ModelBase{
        
        public string FirstName {get; set; }
        public string? LastName {get; set; }
        public string Email {get; set; }
        public UserRole? UserRole { get; set; }
        public int UserRoleId { get; set; }
        public Acces? Acces { get; set; }
        public int AccesId { get; set; }
    }
}