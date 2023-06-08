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