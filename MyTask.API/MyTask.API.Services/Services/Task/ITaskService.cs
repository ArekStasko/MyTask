using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.TaskControllers;

public interface ITaskService
{
    Task<TaskDTO> Create(TaskDTO taskDTO, string userId);
    Task<bool> Delete(int id, string userId);
    Task<TaskDTO> Update(TaskDTO taskDTO, string userId);
    Task<List<TaskDTO>> Get(int projectId, string userId);
    Task<TaskDTO> GetSingle(int id, string userId);
}