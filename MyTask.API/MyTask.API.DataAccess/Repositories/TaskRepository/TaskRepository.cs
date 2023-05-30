using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Repositories.TaskRepository;

public class TaskRepository : ITaskRepository
{
    private DataContext _context;
    public TaskRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Create(ITask task)
    {
        try
        {
            await _context.Tasks.AddAsync(task);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var task = await _context.Tasks.SingleAsync(t => t.Id == id);
            _context.Tasks.Remove(task);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ITask> Update(ITask task)
    {
        try
        {
            await Delete(task.Id);
            await Create(task);
            return task;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<ITask>> Get(int projectId)
    {
        try
        {
            var tasks = _context.Tasks.Where(t => t.ProjectId == projectId);
            return await tasks.ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ITask> GetSingle(int id)
    {
        try
        {
            var task = await _context.Tasks.SingleAsync(t => t.Id == id);
            return task;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}