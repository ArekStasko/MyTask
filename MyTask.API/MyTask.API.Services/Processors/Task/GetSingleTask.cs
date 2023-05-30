using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Task;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class GetSingleTask : IGetSingleTask
{
    private ITaskRepository _repository;

    public GetSingleTask(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<ITask> Execute(int id)
    {
        try
        {
            var task = await _repository.GetSingle(id);
            return task;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}