using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Services.ProjectServices;

public interface IProjectService
{
    Task<ProjectDTO> Create(ProjectDTO project, int userId);
    Task<bool> Delete(int id, int userId);
    Task<List<ProjectDTO>> Get(int userId);
    Task<ProjectDTO> GetSingle(int id, int userId);
}