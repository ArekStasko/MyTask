using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.RaportProcFactory;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Services.RaportControllers;

public class RaportService : IRaportService
{
    private readonly IRaportProcFactory _ProcessorFactory;
    private readonly IMapper _mapper;
    
    public RaportService()
    {
        _ProcessorFactory = new RaportProcFactory();
        _mapper = Mapping.Mapper;
    }

    public async Task<RaportDTO> Generate(RaportDTO raportDTO)
    {
        var raport = _mapper.Map<IRaport>(raportDTO); 
        var processor = _ProcessorFactory.GetGenerateRaport();
        var result = await processor.Execute(raport);
        raportDTO = _mapper.Map<RaportDTO>(result);
        return raportDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var processor = _ProcessorFactory.GetDeleteRaport();
        var result = await processor.Execute(id);
        return result;
    }

    public async Task<List<RaportDTO>> Get()
    {
        var processor = _ProcessorFactory.GetGetRaports();
        var result = await processor.Execute();
        var raportDTO = _mapper.Map<List<RaportDTO>>(result);
        return raportDTO;
    }

    public async Task<RaportDTO> GetSingle(int id)
    {
        var processor = _ProcessorFactory.GetGetSingleRaport();
        var result = await processor.Execute(id);
        var raportDTO = _mapper.Map<RaportDTO>(result);
        return raportDTO;
    }
}