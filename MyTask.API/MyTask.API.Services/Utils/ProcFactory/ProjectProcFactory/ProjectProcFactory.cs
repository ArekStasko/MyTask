using MyTask.API.Services.Processors.ProjectProcessors;
using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.ProjectRepository;

namespace MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;

public class ProjectProcFactory : IProjectProcFactory
{
    private readonly IProjectRepository _repository;
    public ProjectProcFactory(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    public ICreateProject GetCreateProject() => new CreateProject(_repository);
    public IDeleteProject GetDeleteProject() => new DeleteProject(_repository);
    public IGetProjects GetGetProjects() => new GetProjects(_repository);
    public IGetSingleProject GetGetSingleProject() => new GetSingleProject(_repository);
}