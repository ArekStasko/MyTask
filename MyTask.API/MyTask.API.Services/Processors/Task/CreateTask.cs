using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Task;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class CreateTask : ICreateTask
{
    private ITaskRepository _repository;

    public CreateTask(ITaskRepository repository)
    {
        _repository = repository;
    }


    public async Task<ITask> Execute(ITask task)
    {
        try
        {
            await _repository.Create(task);
            var createdTask = await _repository.GetSingle(task.Id);
            return createdTask;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}