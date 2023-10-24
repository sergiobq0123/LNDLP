using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class UserRoleService : GenericService<UserRole>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper, IUriService uriService) : base(userRoleRepository, mapper, uriService)
        {
            _userRoleRepository = userRoleRepository;
        }
    }
}
