using System;

namespace LNDP_API.Models{
    public class Acces : ModelBase{
        
        public string UserName {get; set; }
        public string PasswordHash {get; set; }
        public string PasswordSalt {get; set; }
        public User? User {get; set; }
    }
}