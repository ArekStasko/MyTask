using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Services.ProjectServices;

public interface IProjectService
{
    Task<ProjectDTO> Create(ProjectDTO project);
    Task<bool> Delete(int id);
    Task<List<ProjectDTO>> Get();
    Task<ProjectDTO> GetSingle(int id);
}