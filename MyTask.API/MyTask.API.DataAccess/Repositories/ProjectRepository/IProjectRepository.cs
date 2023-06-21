using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.DataAccess.Repositories.ProjectRepository;

public interface IProjectRepository
{
    Task<bool> Create(IProject project, int userId);
    Task<bool> Delete(int id, int userId);
    Task<List<IProject>> Get(int userId);
    Task<IProject> Get(int id, int userId);
}