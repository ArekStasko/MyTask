using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Processors.TaskProcessors.Interfaces;

public interface IGetTasks
{
    Task<List<ITask>> Execute(int projectId, string userId);
}