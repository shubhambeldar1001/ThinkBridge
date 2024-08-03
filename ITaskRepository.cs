using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskOffice>> GetAllAsync();
        Task<TaskOffice> GetByIdAsync(int id);
        Task<TaskOffice> AddAsync(TaskOffice task);
        Task<TaskOffice> UpdateAsync(TaskOffice task);
        Task<bool> DeleteAsync(int id);
    }
}
