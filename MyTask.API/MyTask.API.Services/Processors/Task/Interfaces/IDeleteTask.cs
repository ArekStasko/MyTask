
namespace MyTask.API.Services.Processors.TaskProcessors.Interfaces;

public interface IDeleteTask
{
    Task<bool> Execute(int id, string userId);
}