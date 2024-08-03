using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
             await _userRepository.DeleteAsync(id);
            return true;
        }

        public List<User> GetUserListByIdsAsync(List<int> ids)
        {
            return _userRepository.GetListByIdsAsync(ids);
        }
    }
}
