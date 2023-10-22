using LNDP_API.Models;

namespace LNDP_API.Dtos{
    public class UserCreateDto{
        //! Usuario 

        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string Email {get; set; }
        public int UserRoleId {get; set;}

        //! Acceso
        public string Username {get; set; }
        public string? Password { get; set; }
        
    }
}