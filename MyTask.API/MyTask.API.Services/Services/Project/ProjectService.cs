using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;
using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.Services.Services.ProjectServices;

namespace MyTask.API.Services.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly IProjectProcFactory _ProcessorFactory;
    private readonly IMapper _mapper;

    public ProjectService()
    {
        _ProcessorFactory = new ProjectProcFactory();
        _mapper = Mapping.Mapper;
    }


    public async Task<ProjectDTO> Create(ProjectDTO projectDTO)
    {
        IProject project = _mapper.Map<IProject>(projectDTO);
        var processor = _ProcessorFactory.GetCreateProject();
        var result = await processor.Execute(project);

        projectDTO = _mapper.Map<ProjectDTO>(result);
        return projectDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var processor = _ProcessorFactory.GetDeleteProject();
        var result = await processor.Execute(id);
        return result;
    }

    public async Task<List<ProjectDTO>> Get()
    {
        var processor = _ProcessorFactory.GetGetProjects();
        var result = await processor.Execute();
        var projectsDTO = _mapper.Map<List<ProjectDTO>>(result);
        return projectsDTO;
    }

    public async Task<ProjectDTO> GetSingle(int id)
    {
        var processor = _ProcessorFactory.GetGetSingleProject();
        var result = await processor.Execute(id);
        var projectDTO = _mapper.Map<ProjectDTO>(result);
        return projectDTO;
    }
}