using Microsoft.EntityFrameworkCore;
using LNDP_API.Data;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly APIContext _context;
        public UserRoleRepository(APIContext context) : base(context)
        {
            _context = context;
        }
    }
}
