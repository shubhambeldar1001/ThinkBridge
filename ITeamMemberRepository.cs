using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITeamMemberRepository
    {
        Task<IEnumerable<TeamMember>> GetAllAsync();
        Task<TeamMember> GetByIdAsync(int id);
        Task<TeamMember> AddAsync(TeamMember task);
        Task<TeamMember> UpdateAsync(TeamMember task);
        Task<bool> DeleteAsync(int id);

    }
}
