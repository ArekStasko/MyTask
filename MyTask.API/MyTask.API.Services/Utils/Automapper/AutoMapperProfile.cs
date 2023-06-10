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
        CreateMap<TaskDTO, _Task>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        CreateMap<RaportDTO, Raport>();
        CreateMap<ProjectDTO, Project>();

        CreateMap<Task, TaskDTO>();
        CreateMap<Raport, RaportDTO>();
        CreateMap<Project, ProjectDTO>();
        

        CreateMap<List<Task>, List<TaskDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<Task>, List<TaskDTO>>(source));
        CreateMap<List<Raport>, List<RaportDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<Raport>, List<RaportDTO>>(source));
        CreateMap<List<Project>, List<ProjectDTO>>()
            .ConvertUsing((source, destination, context) => context.Mapper.Map<List<Project>, List<ProjectDTO>>(source));
            
    }    
}