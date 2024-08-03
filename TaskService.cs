using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskOffice>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskOffice> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<TaskOffice> AddTaskAsync(TaskOffice task)
        {
            await _taskRepository.AddAsync(task);
            return task;
        }

        public async Task<TaskOffice> UpdateTaskAsync(TaskOffice task)
        {
            await _taskRepository.UpdateAsync(task);
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
            return true;
        }

    }
}
