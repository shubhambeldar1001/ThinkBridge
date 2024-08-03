using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();
        Task<TeamMember> GetTeamMemberByIdAsync(int id);
        Task AddTeamMemberAsync(TeamMember teamMember);
        Task UpdateTeamMemberAsync(TeamMember teamMember);
        Task DeleteTeamMemberAsync(int id);
    }
}
