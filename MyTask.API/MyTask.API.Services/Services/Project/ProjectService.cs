using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.Services.Services.ProjectServices;

namespace MyTask.API.Services.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly IProjectProcFactory _processorFactory;
    private readonly IMapper _mapper;

    public ProjectService(IProjectProcFactory processorFactory, IMapper mapper)
    {
        _processorFactory = processorFactory;
        _mapper = mapper;
    }


    public async Task<ProjectDTO> Create(ProjectDTO projectDTO, string userId)
    {
        IProject project = _mapper.Map<Project>(projectDTO);
        var processor = _processorFactory.GetCreateProject();
        var result = await processor.Execute(project, userId);

        projectDTO = _mapper.Map<ProjectDTO>(result);
        return projectDTO;
    }

    public async Task<bool> Delete(int id, string userId)
    {
        var processor = _processorFactory.GetDeleteProject();
        var result = await processor.Execute(id, userId);
        return result;
    }

    public async Task<List<ProjectDTO>> Get(string userId)
    {
        var processor = _processorFactory.GetGetProjects();
        var result = await processor.Execute(userId);
        var projectsDto = _mapper.Map<List<ProjectDTO>>(result);
        return projectsDto;
    }

    public async Task<ProjectDTO> GetSingle(int id, string userId)
    {
        var processor = _processorFactory.GetGetSingleProject();
        var result = await processor.Execute(id, userId);
        var projectsDto = _mapper.Map<ProjectDTO>(result);
        return projectsDto;
    }
}