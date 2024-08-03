using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> AddAsync(Team team);
        Task<bool> UpdateAsync(Team team);
        Task<bool> DeleteAsync(int id);
    }
}
