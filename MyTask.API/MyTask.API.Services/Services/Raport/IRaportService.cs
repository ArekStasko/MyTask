using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Services.RaportControllers;

public interface IRaportService
{
    Task<RaportDTO> Generate(int projectId, string userId);
    Task<bool> Delete(int id, string userId);
    Task<List<RaportDTO>> Get(string userId);
    Task<RaportDTO> GetSingle(int id, string userId);
}