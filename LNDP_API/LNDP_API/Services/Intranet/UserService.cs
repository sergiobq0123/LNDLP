using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateAsync(user);
        }
        
        public async Task<bool> ExistUser(int idUser)
        {
            return await _userRepository.ExistUserAsync(idUser);
        }
        public async Task<User> UpdateUser(User User)
        {
            return await _userRepository.UpdateAsync(User);
        }

        public async Task DeleteUser(int idUser)
        {
            await _userRepository.DeleteAsync(idUser);
        }
        

    }
}
