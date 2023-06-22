using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Task;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class UpdateTask : IUpdateTask
{
    private ITaskRepository _repository;

    public UpdateTask(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<ITask> Execute(ITask task, string userId)
    {
        try
        {
            var result = await _repository.Update(task, userId);
            return result;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}