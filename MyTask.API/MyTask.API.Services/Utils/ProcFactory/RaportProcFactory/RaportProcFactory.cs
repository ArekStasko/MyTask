using MyTask.API.Services.Processors.RaportProcessors;
using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Services.RepositoriesFactory;

namespace MyTask.API.Services.Services.ProcFactory.RaportProcFactory;

public class RaportProcFactory : IRaportProcFactory
{
    private readonly IRaportRepository _repository = RepositoriesFactory.GetRaportRepo(); 
    
    public IGenerateRaport GetGenerateRaport() => new GenerateRaport(_repository);
    public IDeleteRaport GetDeleteRaport() => new DeleteRaport(_repository);
    public IGetRaports GetGetRaports() => new GetRaports(_repository);
    public IGetSingleRaport GetGetSingleRaport() => new GetSingleRaport(_repository);
}