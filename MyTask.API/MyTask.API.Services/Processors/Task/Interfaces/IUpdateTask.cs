using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Processors.TaskProcessors.Interfaces;

public interface IUpdateTask
{
    Task<ITask> Execute(ITask task);
}