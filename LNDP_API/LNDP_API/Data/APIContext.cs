using Microsoft.EntityFrameworkCore;
using LNDP_API.Models;
using LNDP_API.Utils;


namespace LNDP_API.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<LNDP_API.Models.User> User { get; set; }
        public DbSet<LNDP_API.Models.Artist> Artist { get; set; }
        public DbSet<LNDP_API.Models.SocialNetwork> SocialNetwork { get; set; }
        public DbSet<LNDP_API.Models.UserRole> UserRole { get; set; }
        public DbSet<LNDP_API.Models.Album> Album { get; set; }
        public DbSet<LNDP_API.Models.Song> Song { get; set; }
        public DbSet<LNDP_API.Models.Company> Company { get; set; }
        public DbSet<LNDP_API.Models.CompanyType> CompanyType { get; set; }
        public DbSet<LNDP_API.Models.Concert> Concert { get; set; }
        public DbSet<LNDP_API.Models.Festival> Festival { get; set; }
        public DbSet<LNDP_API.Models.ArtistFestivalAsoc> ArtistFestivalAsoc { get; set; }
        public DbSet<LNDP_API.Models.YoutubeVideo> YoutubeVideo { get; set; }
        public DbSet<LNDP_API.Models.Acces> Acces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    Role = "Visual"
                },
                new LNDP_API.Models.UserRole
                {
                    Id = 3,
                    Role = "Crew"
                }
            );

            var passwordSalt = PasswordHasher.GenerateSalt();
            modelBuilder.Entity<LNDP_API.Models.Acces>()
            .HasData(
                new LNDP_API.Models.Acces
                {
                    Id = 1,
                    UserName = "Sanchez",
                    PasswordSalt = passwordSalt,
                    PasswordHash = PasswordHasher.ComputeHash("sanchez", passwordSalt, "pepper", 3),
                },
                new LNDP_API.Models.Acces
                {
                    Id = 2,
                    UserName = "Torres",
                    PasswordSalt = passwordSalt,
                    PasswordHash = PasswordHasher.ComputeHash("torres", passwordSalt, "pepper", 3),
                },
                new LNDP_API.Models.Acces
                {
                    Id = 3,
                    UserName = "Tomas",
                    PasswordSalt = passwordSalt,
                    PasswordHash = PasswordHasher.ComputeHash("tomas", passwordSalt, "pepper", 3),
                },
                new LNDP_API.Models.Acces
                {
                    Id = 4,
                    UserName = "Iglesias",
                    PasswordSalt = passwordSalt,
                    PasswordHash = PasswordHasher.ComputeHash("iglesias", passwordSalt, "pepper", 3),
                }
            );

            modelBuilder.Entity<LNDP_API.Models.User>()
            .HasData(
                new LNDP_API.Models.User
                {
                    Id = 1,
                    FirstName = "Sergio",
                    LastName = "Sanchez",
                    Email = "Sanchez",
                    UserRoleId = 1,
                    AccesId = 1
                },
                new LNDP_API.Models.User
                {
                    Id = 2,
                    FirstName = "Jorge",
                    LastName = "Torres",
                    Email = "Torres",
                    UserRoleId = 1,
                    AccesId = 2
                },
                new LNDP_API.Models.User
                {
                    Id = 3,
                    FirstName = "Tomas",
                    LastName = "De la Fuente",
                    Email = "Tomas",
                    UserRoleId = 1,
                    AccesId = 3
                },
                new LNDP_API.Models.User
                {
                    Id = 4,
                    FirstName = "Alvaro",
                    LastName = "Iglesias",
                    Email = "Iglesias",
                    UserRoleId = 2,
                    AccesId = 4
                }
            );

            modelBuilder.Entity<LNDP_API.Models.CompanyType>().HasData
            (
                new LNDP_API.Models.CompanyType
                {
                    Id = 1,
                    Name = "Marca"
                },
                new LNDP_API.Models.CompanyType
                {
                    Id = 2,
                    Name = "Partner"
                },
                new LNDP_API.Models.CompanyType
                {
                    Id = 3,
                    Name = "Sello"
                },
                new LNDP_API.Models.CompanyType
                {
                    Id = 4,
                    Name = "Proyecto"
                }

            );
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(e => e.Artist)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(e => e.Artist)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.SocialNetwork)
                .WithOne(sm => sm.Artist)
                .HasForeignKey<SocialNetwork>(sm => sm.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Concerts)
                .WithOne(e => e.Artist)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtistFestivalAsoc>()
                .HasOne(afa => afa.Artist)
                .WithMany(a => a.ArtistFestivalAsoc)
                .HasForeignKey(afa => afa.ArtistId);

            modelBuilder.Entity<ArtistFestivalAsoc>()
                .HasOne(afa => afa.Festival)
                .WithMany(f => f.ArtistFestivalAsoc)
                .HasForeignKey(afa => afa.FestivalId);
        }
    }
}






