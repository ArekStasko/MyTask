using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.Automapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskDTO, ITask>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        CreateMap<RaportDTO, IRaport>();
        CreateMap<ProjectDTO, IProject>();

        CreateMap<ITask, TaskDTO>();
        CreateMap<IRaport, RaportDTO>();
        CreateMap<IProject, ProjectDTO>();
        

        CreateMap<List<ITask>, List<TaskDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<ITask>, List<TaskDTO>>(source));
        CreateMap<List<IRaport>, List<RaportDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<IRaport>, List<RaportDTO>>(source));
        CreateMap<List<IProject>, List<ProjectDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<IProject>, List<ProjectDTO>>(source));
            
    }    
}