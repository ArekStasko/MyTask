
namespace MyTask.API.Services.Processors.ProjectProcessors.Interfaces;

public interface IDeleteProject
{
    Task<bool> Execute(int id, string userId);
}