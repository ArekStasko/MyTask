using MyTask.API.Services.Processors.RaportProcessors;
using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Services.ProcFactory.RaportProcFactory;

public class RaportProcFactory : IRaportProcFactory
{
    private readonly IRaportRepository _raportRepository;
    private readonly ITaskRepository _taskRepository;

    public RaportProcFactory(IRaportRepository raportRepository, ITaskRepository taskRepository)
    {
        _raportRepository = raportRepository;
        _taskRepository = taskRepository;
    }
    
    public IGenerateRaport GetGenerateRaport() => new GenerateRaport(_raportRepository,  _taskRepository);
    public IDeleteRaport GetDeleteRaport() => new DeleteRaport(_raportRepository);
    public IGetRaports GetGetRaports() => new GetRaports(_raportRepository);
    public IGetSingleRaport GetGetSingleRaport() => new GetSingleRaport(_raportRepository);
}