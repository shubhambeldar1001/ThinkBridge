using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService; 

        public TeamsController(ITeamService teamService, IUserService userService)
        {
            _teamService = teamService;
            _userService = userService;
        }
        public class CreateTeamRequest
        {
            public string Name { get; set; }
            public List<int> UserIds { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            try
            {
                var teams = await _teamService.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            try
            {
                var team = await _teamService.GetTeamByIdAsync(id);
                if (team == null)
                {
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [HttpPost]
        public async Task<ActionResult> CreateTeam([FromBody] CreateTeamRequest request)
        {
            try
            {
                var users = _userService.GetUserListByIdsAsync(request.UserIds);

                var teamMember = new TeamMember
                {
                    User = users,
                    TeamName = request?.Name,
                };

                var team = new Team
                {
                    TeamName = request.Name,
                    TeamMembers = teamMember
                };


                await _teamService.AddTeamAsync(team);
                return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam(int id, [FromBody] Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            await _teamService.UpdateTeamAsync(team);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id); 
            return NoContent();
        }
    }
}

