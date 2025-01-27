using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("tasks")]
        public async Task<IEnumerable<TaskDTO>> GetTasks()
            => await _taskService.GetTasks();

        [HttpGet("get-task-by-id/{id}")]
        public async Task<ActionResult<TaskDTO>> GetTaskByID(int id)
            => await _taskService.GetTaskByID(id);

        [HttpPost("add-task")]
        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO taskDto)
            => await _taskService.CreateTask(taskDto);

        [HttpPut("update-task/{id}")]
        public async Task<ActionResult<TaskDTO>> UpdateTask(UpdateTaskDTO taskDto, int id)
            => await _taskService.UpdateTask(taskDto, id);

        [HttpDelete("delete-task/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
            => await _taskService.DeleteTask(id);
    }
}