using Microsoft.EntityFrameworkCore;
using LNDP_API.Models;


namespace LNDP_API.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options){}
        public DbSet<LNDP_API.Models.User> User {get ; set ; }
    }
}






