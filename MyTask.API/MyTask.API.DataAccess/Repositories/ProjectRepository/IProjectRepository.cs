using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.DataAccess.Repositories.ProjectRepository;

public interface IProjectRepository
{
    Task<bool> Create(IProject project);
    Task<bool> Delete(int id);
    Task<List<IProject>> Get();
    Task<IProject> Get(int id);
}