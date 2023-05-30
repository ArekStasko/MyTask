using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Repositories.RaportRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class GetRaports : IGetRaports
{
    private IRaportRepository _repository;

    public GetRaports(IRaportRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IRaport>> Execute()
    {
        try
        {
            var raports = await _repository.Get();
            return raports;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}