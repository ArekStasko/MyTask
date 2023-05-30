using MyTask.API.Services.Processors.RaportProcessors.Interfaces;

namespace MyTask.API.Services.Services.ProcFactory.RaportProcFactory;

public interface IRaportProcFactory
{
    IGenerateRaport GetGenerateRaport();
    IDeleteRaport GetDeleteRaport();
    IGetRaports GetGetRaports();
    IGetSingleRaport GetGetSingleRaport();
}