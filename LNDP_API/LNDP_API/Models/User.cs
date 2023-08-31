using System;

namespace LNDP_API.Models{
    public class User : ModelBase{
        
        public string? Username {get; set; }
        public string? Email {get; set; }
        public byte[]? PasswordHash {get; set; }
        public byte[]? PasswordSalt {get; set; }

    }
}