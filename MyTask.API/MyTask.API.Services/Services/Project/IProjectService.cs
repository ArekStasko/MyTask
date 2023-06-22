using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Services.ProjectServices;

public interface IProjectService
{
    Task<ProjectDTO> Create(ProjectDTO project, string userId);
    Task<bool> Delete(int id, string userId);
    Task<List<ProjectDTO>> Get(string userId);
    Task<ProjectDTO> GetSingle(int id, string userId);
}