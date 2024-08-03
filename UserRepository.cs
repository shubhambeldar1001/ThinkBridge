using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TaskManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<User> GetListByIdsAsync(List<int> ids)
        {
            return _context.Users.Where(u => ids.Contains(u.UserId)).ToList();
        }
    }
}
