using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Repositories.ProjectRepository;

namespace MyTask.API.Services.Processors.ProjectProcessors;

public class GetProjects : IGetProjects
{
    private IProjectRepository _repository;

    public GetProjects(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IProject>> Execute()
    {
        try
        {
            var projects = await _repository.Get();
            return projects;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}