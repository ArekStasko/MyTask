using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.DataAccess.Repositories.RaportRepository;

public interface IRaportRepository
{
    Task<bool> Generate(IRaport raport);
    Task<bool> Delete(int id);
    Task<List<IRaport>> Get();
    Task<IRaport> Get(int id);
}