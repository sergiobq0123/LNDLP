namespace LNDP_API.Dtos{
    public class UserLoginDto{
        public string Email {get; set; }
        public string Password { get; set; }
        public int UserRole {get; set; }
    }
}