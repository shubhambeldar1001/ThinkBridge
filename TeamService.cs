using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(id);
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            await _teamRepository.AddAsync(team);
            return team;    
        }

        public async Task<bool> UpdateTeamAsync(Team team)
        {
            await _teamRepository.UpdateAsync(team);
            return true;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
            return true;
        }
    }
}
