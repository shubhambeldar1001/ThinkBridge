/*using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAttachmentsController : ControllerBase
    {
        private readonly ITaskAttachmentService _taskAttachmentService;

        public TaskAttachmentsController(ITaskAttachmentService taskAttachmentService)
        {
            _taskAttachmentService = taskAttachmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskAttachment>>> GetTaskAttachments()
        {
            var attachments = await _taskAttachmentService.GetAllTaskAttachmentsAsync();
            return Ok(attachments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAttachment>> GetTaskAttachment(int id)
        {
            var attachment = await _taskAttachmentService.GetTaskAttachmentByIdAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            return Ok(attachment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaskAttachment([FromBody] TaskAttachment attachment)
        {
            await _taskAttachmentService.AddTaskAttachmentAsync(attachment);
            return CreatedAtAction(nameof(GetTaskAttachment), new { id = attachment.TaskAttachmentId }, attachment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTaskAttachment(int id, [FromBody] TaskAttachment attachment)
        {
            if (id != attachment.TaskAttachmentId)
            {
                return BadRequest();
            }

            await _taskAttachmentService.UpdateTaskAttachmentAsync(attachment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskAttachment(int id)
        {
            await _taskAttachmentService.DeleteTaskAttachmentAsync(id);
            return NoContent();
        }
    }
}
*/