using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool>  DeleteUserAsync(int id);
        List<User> GetUserListByIdsAsync(List<int> ids);
    }
}
