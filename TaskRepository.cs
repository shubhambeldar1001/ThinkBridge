using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskOffice>> GetAllAsync()
        {
            return await _context.TaskOffices.ToListAsync();
        }

        public async Task<TaskOffice> GetByIdAsync(int id)
        {
            return await _context.TaskOffices.FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<TaskOffice> AddAsync(TaskOffice entity)
        {
            await _context.TaskOffices.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        public async Task<TaskOffice> UpdateAsync(TaskOffice entity)
        {
            _context.TaskOffices.Update(entity);
            await _context.SaveChangesAsync();
                return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.TaskOffices.FindAsync(id);
            if (task != null)
            {
                _context.TaskOffices.Remove(task);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
