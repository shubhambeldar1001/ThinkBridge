using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;
using System;
namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if(user == null)
            {
                return NoContent();
            }
            try
            {
                await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
            }
            catch(Exception e)
            {
                return BadRequest(e);    
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.UserId)
                {
                    return BadRequest();
                }

                await _userService.UpdateUserAsync(user);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
