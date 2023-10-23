using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccesService _accesService;

        public UserService(IUserRepository userRepository, IMapper mapper, IAccesService accesService) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _accesService = accesService;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> PostUser(UserCreateDto userCreateDto)
        {
            Acces newAcces = await _accesService.Register(_mapper.Map<AccesDto>(userCreateDto));

            User user = _mapper.Map<User>(userCreateDto);
            user.AccesId = newAcces.Id;
            return await _userRepository.CreateAsync(user);
        }
    }
}
