using MyTask.API.Services.Processors.ProjectProcessors;
using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.DataAccess.Services.RepositoriesFactory;

namespace MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;

public class ProjectProcFactory : IProjectProcFactory
{
    private readonly IProjectRepository _repository = RepositoriesFactory.GetProjectRepo();
    
    public ICreateProject GetCreateProject() => new CreateProject(_repository);
    public IDeleteProject GetDeleteProject() => new DeleteProject(_repository);
    public IGetProjects GetGetProjects() => new GetProjects(_repository);
    public IGetSingleProject GetGetSingleProject() => new GetSingleProject(_repository);
}