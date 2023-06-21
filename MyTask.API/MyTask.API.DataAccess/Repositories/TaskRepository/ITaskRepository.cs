using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Repositories.TaskRepository;

public interface ITaskRepository
{
    Task<bool> Create(ITask task, int userId);
    Task<bool> Delete(int id, int userId);
    Task<ITask> Update(ITask task, int userId);
    Task<List<ITask>> Get(int projectId, int userId);
    Task<ITask> GetSingle(int id, int userId);
}