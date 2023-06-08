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


    public async Task<ProjectDTO> Create(ProjectDTO projectDTO)
    {
        IProject project = _mapper.Map<IProject>(projectDTO);
        var processor = _processorFactory.GetCreateProject();
        var result = await processor.Execute(project);

        projectDTO = _mapper.Map<ProjectDTO>(result);
        return projectDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var processor = _processorFactory.GetDeleteProject();
        var result = await processor.Execute(id);
        return result;
    }

    public async Task<List<ProjectDTO>> Get()
    {
        var processor = _processorFactory.GetGetProjects();
        var result = await processor.Execute();
        var projectsDto = _mapper.Map<List<ProjectDTO>>(result);
        return projectsDto;
    }

    public async Task<ProjectDTO> GetSingle(int id)
    {
        var processor = _processorFactory.GetGetSingleProject();
        var result = await processor.Execute(id);
        var projectsDto = _mapper.Map<ProjectDTO>(result);
        return projectsDto;
    }
}