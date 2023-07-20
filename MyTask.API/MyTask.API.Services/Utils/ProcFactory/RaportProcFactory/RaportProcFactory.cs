using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.Services.Processors.RaportProcessors;
using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Services.ProcFactory.RaportProcFactory;

public class RaportProcFactory : IRaportProcFactory
{
    private readonly IRaportRepository _raportRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public RaportProcFactory(IRaportRepository raportRepository, ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _raportRepository = raportRepository;
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }
    
    public IGenerateRaport GetGenerateRaport() => new GenerateRaport(_raportRepository,  _taskRepository, _projectRepository);
    public IDeleteRaport GetDeleteRaport() => new DeleteRaport(_raportRepository);
    public IGetRaports GetGetRaports() => new GetRaports(_raportRepository);
    public IGetSingleRaport GetGetSingleRaport() => new GetSingleRaport(_raportRepository);
}