using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamMember>> GetAllAsync()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        public async Task<TeamMember> GetByIdAsync(int id)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.TeamId == id);
        }

        public async Task<TeamMember> AddAsync(TeamMember entity)
        {
            await _context.TeamMembers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TeamMember> UpdateAsync(TeamMember entity)
        {
            _context.TeamMembers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
