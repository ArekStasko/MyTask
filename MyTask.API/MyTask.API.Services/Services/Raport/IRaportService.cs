using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Services.RaportControllers;

public interface IRaportService
{
    Task<RaportDTO> Generate(RaportDTO raportDTO);
    Task<bool> Delete(int id);
    Task<List<RaportDTO>> Get();
    Task<RaportDTO> GetSingle(int id);
}