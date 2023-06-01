using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.Services.Processors.RaportProcessors;
using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Services.RepositoriesFactory;

namespace MyTask.API.Services.Services.ProcFactory.RaportProcFactory;

public class RaportProcFactory : IRaportProcFactory
{
    //private readonly IRaportRepository _repository = RepositoriesFactory.GetRaportRepo(); 
    
    public IGenerateRaport GetGenerateRaport() => new GenerateRaport(new RaportRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IDeleteRaport GetDeleteRaport() => new DeleteRaport(new RaportRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetRaports GetGetRaports() => new GetRaports(new RaportRepository(new DataContext(new DbContextOptions<DataContext>())));
    public IGetSingleRaport GetGetSingleRaport() => new GetSingleRaport(new RaportRepository(new DataContext(new DbContextOptions<DataContext>())));
}