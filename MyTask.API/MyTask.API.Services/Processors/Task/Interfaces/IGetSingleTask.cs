using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Processors.TaskProcessors.Interfaces;

public interface IGetSingleTask
{
    Task<ITask> Execute(int id, string userId);
}