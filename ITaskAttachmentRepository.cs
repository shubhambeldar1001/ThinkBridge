using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskAttachmentRepository
    {
        Task<IEnumerable<TaskAttachment>> GetAllAsync();
        Task<TaskAttachment> GetByIdAsync(int id);
        Task<TaskAttachment> AddAsync(TaskAttachment attachment);
        Task<TaskAttachment> UpdateAsync(TaskAttachment attachment);
        Task<bool> DeleteAsync(int id);

    }
}
