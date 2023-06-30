using MyTask.API.DataAccess.Data.Models.Task;
using MyTask.API.DataAccess.Repositories.TaskRepository;
using MyTask.API.Services.Processors.TaskProcessors.Interfaces;

namespace MyTask.API.Services.Processors.TaskProcessors;

public class GetAllTasks : IGetAllTasks
{
    private ITaskRepository _repository;
    
    public GetAllTasks(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ITask>> Execute(string userId)
    {
        try
        {
            var tasks = await _repository.GetAll(userId);
            return tasks;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}