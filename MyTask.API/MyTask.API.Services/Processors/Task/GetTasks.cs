using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Task;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class GetTask : IGetTasks
{
    private ITaskRepository _repository;

    public GetTask(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ITask>> Execute(int projectId, int userId)
    {
        try
        {
            var tasks = await _repository.Get(projectId, userId);
            return tasks;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}