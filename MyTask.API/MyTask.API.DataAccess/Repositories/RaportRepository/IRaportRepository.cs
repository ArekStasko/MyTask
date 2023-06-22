using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.DataAccess.Repositories.RaportRepository;

public interface IRaportRepository
{
    Task<bool> Generate(IRaport raport, string userId);
    Task<bool> Delete(int id, string userId);
    Task<List<IRaport>> Get(string userId);
    Task<IRaport> Get(int id, string userId);
}