/*using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TaskAttachmentRepository :ITaskAttachmentRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskAttachmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskAttachment>> GetAllAsync()
        {
            return await _context.TaskAttachments.ToListAsync();
        }

        public async Task<TaskAttachment> GetByIdAsync(int id)
        {
            return await _context.TaskAttachments.FindAsync(id);
        }

        public async Task<TaskAttachment> AddAsync(TaskAttachment entity)
        {
            await _context.TaskAttachments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskAttachment> UpdateAsync(TaskAttachment entity)
        {
            _context.TaskAttachments.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var attachment = await _context.TaskAttachments.FindAsync(id);
            if (attachment != null)
            {
                _context.TaskAttachments.Remove(attachment);
                await _context.SaveChangesAsync();
            }
            return true;
        }

    }
}*/