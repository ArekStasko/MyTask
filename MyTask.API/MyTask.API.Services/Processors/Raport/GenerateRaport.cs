using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Repositories.RaportRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class GenerateRaport : IGenerateRaport
{
    private IRaportRepository _repository;

    public GenerateRaport(IRaportRepository repository)
    {
        _repository = repository;
    }

    public async Task<IRaport> Execute(IRaport raport)
    {
        try
        {
            await _repository.Generate(raport);
            var generatedRaport = await _repository.Get(raport.Id);
            return generatedRaport;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}