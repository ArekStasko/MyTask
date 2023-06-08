using MyTask.API.Services.Processors.TaskProcessors;
using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Services.ProcFactory.TaskProcFactory;

public class TaskProcFactory : ITaskProcFactory
{
    private readonly ITaskRepository _repository;
    public TaskProcFactory(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public ICreateTask GetCreateTask() => new CreateTask(_repository);
    public IDeleteTask GetDeleteTask() => new DeleteTask(_repository);
    public IUpdateTask GetUpdateTask() => new UpdateTask(_repository);
    public IGetTasks GetGetTasks() => new GetTask(_repository);
    public IGetSingleTask GetGetSingleTask() => new GetSingleTask(_repository);
}