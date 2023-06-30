using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Data.Enums;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Repositories.TaskRepository;

public class TaskRepository : ITaskRepository
{
    private DataContext _context;
    public TaskRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Create(ITask task, string userId)
    {
        try
        {
            await _context.Tasks.AddAsync((_Task)task);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Delete(int id, string userId)
    {
        try
        {
            var task = await _context.Tasks.SingleAsync(t => t.Id == id && t.UserId == userId);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ITask> Update(ITask task, string userId)
    {
        try
        {
            var taskToUpdate = await _context.Tasks.SingleAsync(t => t.Id == task.Id && t.UserId == userId);

            taskToUpdate.Name = task.Name;
            taskToUpdate.Description = task.Name;
            taskToUpdate.State = task.State;
            
            await _context.SaveChangesAsync();
            return taskToUpdate;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<ITask>> Get(int projectId, string userId)
    {
        try
        {
            var tasks = _context.Tasks.Where(t => t.ProjectId == projectId && t.UserId == userId);
            return await tasks.ToListAsync<ITask>();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<ITask>> GetAll(string userId)
    {
        try
        {
            var tasks = _context.Tasks;
            return await tasks.ToListAsync<ITask>();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ITask> GetSingle(int id, string userId)
    {
        try
        {
            var task = await _context.Tasks.SingleAsync(t => t.Id == id && t.UserId == userId);
            return task;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}