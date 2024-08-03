using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskOffice>> GetAllTasksAsync();
        Task<TaskOffice> GetTaskByIdAsync(int id);
        Task<TaskOffice> AddTaskAsync(TaskOffice task);
        Task<TaskOffice> UpdateTaskAsync(TaskOffice task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
