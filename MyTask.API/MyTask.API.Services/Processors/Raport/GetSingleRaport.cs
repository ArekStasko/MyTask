using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Repositories.RaportRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class GetSingleRaport : IGetSingleRaport
{
    private IRaportRepository _repository;

    public GetSingleRaport(IRaportRepository repository)
    {
        _repository = repository;
    }

    public async Task<IRaport> Execute(int id)
    {
        try
        {
            var raport = await _repository.Get(id);
            return raport;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}