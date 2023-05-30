using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.Automapper;

public static class Mapping
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg => {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<AutoMapperProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskDTO, ITask>();
        CreateMap<RaportDTO, IRaport>();
        CreateMap<ProjectDTO, IProject>();

        CreateMap<ITask, TaskDTO>();
        CreateMap<IRaport, RaportDTO>();
        CreateMap<IProject, ProjectDTO>();
        
        CreateMap<List<ITask>, List<TaskDTO>>();
        CreateMap<List<IRaport>, List<RaportDTO>>();
        CreateMap<List<IProject>, List<ProjectDTO>>();
    }    
}