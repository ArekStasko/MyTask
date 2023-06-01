using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.Services.Processors.ProjectProcessors;
using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.DataAccess.Services.RepositoriesFactory;

namespace MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;

public class ProjectProcFactory : IProjectProcFactory
{
    //private readonly IProjectRepository _repository = RepositoriesFactory.GetProjectRepo();
    
    public ICreateProject GetCreateProject() => new CreateProject(new ProjectRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IDeleteProject GetDeleteProject() => new DeleteProject(new ProjectRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetProjects GetGetProjects() => new GetProjects(new ProjectRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetSingleProject GetGetSingleProject() => new GetSingleProject(new ProjectRepository(new DataContext(new DbContextOptions<DataContext>())));
}