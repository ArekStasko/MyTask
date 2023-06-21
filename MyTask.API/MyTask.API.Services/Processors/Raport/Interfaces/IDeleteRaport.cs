
namespace MyTask.API.Services.Processors.RaportProcessors.Interfaces;

public interface IDeleteRaport
{
    Task<bool> Execute(int id, int userId);
}