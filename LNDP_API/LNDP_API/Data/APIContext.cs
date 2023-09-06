using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LNDP_API.Models;


namespace LNDP_API.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options){}

        public DbSet<LNDP_API.Models.User> User {get ; set ; }
        public DbSet<LNDP_API.Models.Artist> Artist {get ; set ; }
        public DbSet<LNDP_API.Models.Concert> Concert {get ; set ; }
        public DbSet<LNDP_API.Models.Crew> Crew {get ; set ; }
        public DbSet<LNDP_API.Models.Dosier> Dosier {get ; set ; }
        public DbSet<LNDP_API.Models.Festival> Festival {get ; set ; }
        public DbSet<LNDP_API.Models.Photo> Photo {get ; set ; }
        public DbSet<LNDP_API.Models.SocialNetwork> SocialNetwork {get ; set ; }

    }
}






