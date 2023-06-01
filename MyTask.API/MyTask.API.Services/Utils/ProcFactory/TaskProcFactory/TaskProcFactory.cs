using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.Services.Processors.TaskProcessors;
using MyTask.API.Services.Processors.TaskProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.TaskRepository;
using MyTask.API.DataAccess.Services.RepositoriesFactory;

namespace MyTask.API.Services.Services.ProcFactory.TaskProcFactory;

public class TaskProcFactory : ITaskProcFactory
{
    //TODO IMPLEMENT AUTOMAPPER
    
    //private readonly ITaskRepository _repository = RepositoriesFactory.GetTaskRepo();
    
    public ICreateTask GetCreateTask() => new CreateTask(new TaskRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IDeleteTask GetDeleteTask() => new DeleteTask(new TaskRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IUpdateTask GetUpdateTask() => new UpdateTask(new TaskRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetTasks GetGetTasks() => new GetTask(new TaskRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetSingleTask GetGetSingleTask() => new GetSingleTask(new TaskRepository(new DataContext(new DbContextOptions<DataContext>())));
}