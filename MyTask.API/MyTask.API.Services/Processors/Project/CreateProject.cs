using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Repositories.ProjectRepository;

namespace MyTask.API.Services.Processors.ProjectProcessors;

public class CreateProject : ICreateProject
{
    private IProjectRepository _repository;

    public CreateProject(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IProject> Execute(IProject project)
    {
        try
        {
            await _repository.Create(project);
            var createdProject = await _repository.Get(project.Id);

            return createdProject;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}