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
        public DbSet<LNDP_API.Models.Crew> Crew {get ; set ; }
        public DbSet<LNDP_API.Models.Dossier> Dossier {get ; set ; }
        public DbSet<LNDP_API.Models.SocialNetwork> SocialNetwork {get ; set ; }
        public DbSet<LNDP_API.Models.Event> Event {get ; set ; }
        public DbSet<LNDP_API.Models.EventType> EventType {get ; set ; }
        public DbSet<LNDP_API.Models.UserRole> UserRole {get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<LNDP_API.Models.EventType>().HasData
            (
                new LNDP_API.Models.EventType
                {
                    Id = 1,
                    EventName = "Festival"
                },
                new LNDP_API.Models.EventType
                {
                    Id = 2,
                    EventName = "Concierto"
                }
                
            );
            modelBuilder.Entity<LNDP_API.Models.UserRole>().HasData
            (
                new LNDP_API.Models.UserRole
                {
                    Id = 1,
                    Role = "Admin"
                },
                new LNDP_API.Models.UserRole
                {
                    Id = 2,
                    Role = "Crew"
                }
                
            );
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Events)
                .WithOne(e => e.Artist)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.SocialNetwork)
                .WithOne(sm => sm.Artist)
                .HasForeignKey<SocialNetwork>(sm => sm.ArtistId)
                .OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Crew)
                .WithOne(sm => sm.Artist)
                .HasForeignKey<Crew>(sm => sm.ArtistId)
                .OnDelete(DeleteBehavior.Cascade); 
    
        }
    }
}






