using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;     

        public TasksController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService; 
        }
        public class CreateTaskRequest
        {
          
         
            public string Title { get; set; }
            public string Description { get; set; }
            // public int AssignedTo { get; set; }
            //public int CreatedBy { get; set; }
            public DateTime DueDate { get; set; }

            [DefaultValue("Pending")]
            public string Status { get; set; }  // Pending, In Progress, Completed

            public int AssignedUserId { get; set; }
            public int CreatedUserId { get; set; }
            public string NoteContent { get; set; }
            public string FilePath { get; set; }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskOffice>>> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskOffice>> GetTask(int id)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            try
            {
                var assignedUser = await _userService.GetUserByIdAsync(request.AssignedUserId);
                var createdUser = await _userService.GetUserByIdAsync(request.CreatedUserId);

                var task = new TaskOffice
                {
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    Status = request.Status,
                    AssignedUser = assignedUser,
                    CreatedUser = createdUser,
                    UploadedAt = DateTime.Now,
                    NoteContent = request.NoteContent,
                    AssignedUserId = request.AssignedUserId,
                    FilePath = request.FilePath

                };
                await _taskService.AddTaskAsync(task);
                return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] TaskOffice task)
        {
            try
            {
                if (id != task.TaskId)
                {
                    return BadRequest();
                }

                await _taskService.UpdateTaskAsync(task);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
