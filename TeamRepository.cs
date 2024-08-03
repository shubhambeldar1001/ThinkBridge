using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _context.Teams.Include(t => t.TeamMembers).FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<Team> AddAsync(Team entity)
        {
            await _context.Teams.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        public async Task<bool> UpdateAsync(Team entity)
        {
            _context.Teams.Update(entity);
            await _context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            return true;    
        }
    }
}
