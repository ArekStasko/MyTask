using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Processors.TaskProcessors.Interfaces;

public interface IGetAllTasks
{
    Task<List<ITask>> Execute(string userId);
}