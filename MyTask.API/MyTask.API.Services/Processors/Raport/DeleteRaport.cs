using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.RaportRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class DeleteRaport : IDeleteRaport
{
    private IRaportRepository _repository;

    public DeleteRaport(IRaportRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Execute(int id, int userId)
    {
        try
        {
            var result = await _repository.Delete(id, userId);
            return result;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}