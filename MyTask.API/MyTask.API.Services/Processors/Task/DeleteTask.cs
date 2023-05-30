using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class DeleteTask : IDeleteTask
{
    private ITaskRepository _repository;

    public DeleteTask(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Execute(int id)
    {
        try
        {
            var result = await _repository.Delete(id);
            return result;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}