using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly CaseDbContext _context;
        public TaskService(CaseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks.Select(task => new TaskDTO
            {
                Id = task.Id,
                CaseId = task.CaseId,
                Title = task.Title,
                Details = task.Details,
                Status = task.Status,
                DateCreated = task.DateCreated,
                DueDate = task.DueDate,
            });
        }

        public async Task<ActionResult<TaskDTO>> GetTaskByID(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                throw new ArgumentException("Task not found");
            }

            return new TaskDTO
            {
                Id = task.Id,
                CaseId = task.CaseId,
                Title = task.Title,
                Details = task.Details,
                Status = task.Status,
                DateCreated = task.DateCreated,
                DueDate = task.DueDate
            };
        }

        public async Task<ActionResult<TaskDTO>> UpdateTask(UpdateTaskDTO task, int id)
        {
            var originalTask = await _context.Tasks.FindAsync(id);

            if (originalTask == null)
                throw new ArgumentException("Task not found");

            originalTask.Title = task.Title;
            originalTask.Details = task.Details;
            originalTask.Status = task.Status;
            originalTask.DueDate = task.DueDate;

            _context.Tasks.Update(originalTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Task updated successfully!");
        }

        public async Task<ActionResult> DeleteTask(int id)
        {
            var originalTask = await _context.Tasks.FindAsync(id);

            if (originalTask == null)
                throw new ArgumentException("Task not found");

            _context.Tasks.Remove(originalTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Task deleted successfully!");
        }

        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO task)
        {
            var newTask = new DTask
            {
                CaseId = task.CaseId,
                Title = task.Title,
                Details = task.Details,
                Status = task.Status,
                DateCreated = DateTime.Now,
                DueDate = task.DueDate,
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Task created successfully!");
        }
    }
}