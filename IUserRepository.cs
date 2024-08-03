using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(int id);
        List<User> GetListByIdsAsync(List<int> ids);   
    }
}
