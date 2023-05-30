using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.DataAccess.Repositories.TaskRepository;

public interface ITaskRepository
{
    Task<bool> Create(ITask task);
    Task<bool> Delete(int id);
    Task<ITask> Update(ITask task);
    Task<List<ITask>> Get(int projectId);
    Task<ITask> GetSingle(int id);
}