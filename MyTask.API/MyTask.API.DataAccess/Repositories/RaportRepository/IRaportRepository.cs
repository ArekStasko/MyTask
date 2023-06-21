using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.DataAccess.Repositories.RaportRepository;

public interface IRaportRepository
{
    Task<bool> Generate(IRaport raport, int userId);
    Task<bool> Delete(int id, int userId);
    Task<List<IRaport>> Get(int userId);
    Task<IRaport> Get(int id, int userId);
}