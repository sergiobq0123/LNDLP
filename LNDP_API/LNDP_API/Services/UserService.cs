using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccesService _accesService;

        public UserService(IUserRepository userRepository, IMapper mapper, IAccesService accesService, IUriService uriService) : base(userRepository, mapper, uriService)
        {
            _userRepository = userRepository;
            _accesService = accesService;
        }

        public async Task<PagedResponse<List<User>>> GetUsers([FromQuery] PaginationFilter paginationFilter, string route)
        {
            IQueryable<User> query = await _userRepository.GetUsersAsync();
            return await this.GetPagination(paginationFilter, query, route);
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
