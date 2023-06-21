using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.RaportProcFactory;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Services.RaportControllers;

public class RaportService : IRaportService
{
    private readonly IRaportProcFactory _processorFactory;
    private readonly IMapper _mapper;
    
    public RaportService(IRaportProcFactory raportProcFactory, IMapper mapper)
    {
        _processorFactory = raportProcFactory;
        _mapper = mapper;
    }

    public async Task<RaportDTO> Generate(int projectId, int userId)
    {
        var processor = _processorFactory.GetGenerateRaport();
        var result = await processor.Execute(projectId, userId);
        var raportDTO = _mapper.Map<RaportDTO>(result);
        return raportDTO;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        var processor = _processorFactory.GetDeleteRaport();
        var result = await processor.Execute(id, userId);
        return result;
    }

    public async Task<List<RaportDTO>> Get(int userId)
    {
        var processor = _processorFactory.GetGetRaports();
        var result = await processor.Execute(userId);
        var raportDTO = _mapper.Map<List<RaportDTO>>(result);
        return raportDTO;
    }

    public async Task<RaportDTO> GetSingle(int id, int userId)
    {
        var processor = _processorFactory.GetGetSingleRaport();
        var result = await processor.Execute(id, userId);
        var raportDTO = _mapper.Map<RaportDTO>(result);
        return raportDTO;
    }
}