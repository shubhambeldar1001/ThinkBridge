/*using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class TaskAttachmentService : ITaskAttachmentService
    {
        private readonly ITaskAttachmentRepository _taskAttachmentRepository;

        public TaskAttachmentService(ITaskAttachmentRepository taskAttachmentRepository)
        {
            _taskAttachmentRepository = taskAttachmentRepository;
        }

        public async Task<IEnumerable<TaskAttachment>> GetAllTaskAttachmentsAsync()
        {
            return await _taskAttachmentRepository.GetAllAsync();
        }

        public async Task<TaskAttachment> GetTaskAttachmentByIdAsync(int id)
        {
            return await _taskAttachmentRepository.GetByIdAsync(id);
        }

        public async Task AddTaskAttachmentAsync(TaskAttachment attachment)
        {
            await _taskAttachmentRepository.AddAsync(attachment);
        }

        public async Task UpdateTaskAttachmentAsync(TaskAttachment attachment)
        {
            await _taskAttachmentRepository.UpdateAsync(attachment);
        }

        public async Task DeleteTaskAttachmentAsync(int id)
        {
            await _taskAttachmentRepository.DeleteAsync(id);
        }
    }
}
*/