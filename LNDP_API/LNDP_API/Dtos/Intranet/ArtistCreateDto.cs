namespace LNDP_API.Dtos
{
    public class ArtistCreateDto : UserCreateDto
    {
        //! User 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; } = 3;

        //! Acces 
        public string Password { get; set; }
        public string Username { get; set; }

        //! Artist
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string PhotoUrl { get; set; }
        public string RecruitmentEmail { get; set; }
        public string CommunicationEmail { get; set; }
        public string Phone { get; set; }

        //! Redes Sociales
        public string? Instagram { get; set; }
        public string? Youtube { get; set; }
        public string? Spotify { get; set; }
        public string? TikTok { get; set; }
        public string? Twitter { get; set; }
    }
}