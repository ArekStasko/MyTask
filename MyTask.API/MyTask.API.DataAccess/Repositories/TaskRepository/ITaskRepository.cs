using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Repositories.TaskRepository;

public interface ITaskRepository
{
    Task<bool> Create(ITask task, string userId);
    Task<bool> Delete(int id, string userId);
    Task<ITask> Update(ITask task, string userId);
    Task<List<ITask>> Get(int projectId, string userId);
    Task<List<ITask>> GetAll(string userId);
    Task<ITask> GetSingle(int id, string userId);
}