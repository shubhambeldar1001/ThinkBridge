using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task<Team> AddTeamAsync(Team team);
        Task<bool> UpdateTeamAsync(Team team);
        Task<bool> DeleteTeamAsync(int id);
    }
}
