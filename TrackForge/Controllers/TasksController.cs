using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackForge.Data;
using TrackForge.Models;

namespace TrackForge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Tasks.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            return task is null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, TaskItem updated)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task is null) return NotFound();

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.Assignee = updated.Assignee;
            task.Status = updated.Status;
            task.Priority = updated.Priority;
            task.Blocked = updated.Blocked;
            task.BlockerNote = updated.BlockerNote;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task is null) return NotFound();

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
