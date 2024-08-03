using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITaskAttachmentService
    {
        Task<IEnumerable<TaskAttachment>> GetAllTaskAttachmentsAsync();
        Task<TaskAttachment> GetTaskAttachmentByIdAsync(int id);
        Task AddTaskAttachmentAsync(TaskAttachment attachment);
        Task UpdateTaskAttachmentAsync(TaskAttachment attachment);
        Task DeleteTaskAttachmentAsync(int id);
    }
}
