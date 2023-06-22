using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.DataAccess.Repositories.ProjectRepository;

public interface IProjectRepository
{
    Task<bool> Create(IProject project, string userId);
    Task<bool> Delete(int id, string userId);
    Task<List<IProject>> Get(string userId);
    Task<IProject> Get(int id, string userId);
}