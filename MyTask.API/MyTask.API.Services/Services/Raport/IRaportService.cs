using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Services.RaportControllers;

public interface IRaportService
{
    Task<RaportDTO> Generate(int projectId, int userId);
    Task<bool> Delete(int id, int userId);
    Task<List<RaportDTO>> Get(int userId);
    Task<RaportDTO> GetSingle(int id, int userId);
}