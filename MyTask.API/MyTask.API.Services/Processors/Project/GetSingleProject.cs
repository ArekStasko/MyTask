using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Repositories.ProjectRepository;

namespace MyTask.API.Services.Processors.ProjectProcessors;

public class GetSingleProject : IGetSingleProject
{
    private IProjectRepository _repository;

    public GetSingleProject(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IProject> Execute(int id)
    {
        try
        {
            var project = await _repository.Get(id);
            return project;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}