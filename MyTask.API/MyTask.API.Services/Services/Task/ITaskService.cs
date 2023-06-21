using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.TaskControllers;

public interface ITaskService
{
    Task<TaskDTO> Create(TaskDTO taskDTO, int userId);
    Task<bool> Delete(int id, int userId);
    Task<TaskDTO> Update(TaskDTO taskDTO, int userId);
    Task<List<TaskDTO>> Get(int projectId, int userId);
    Task<TaskDTO> GetSingle(int id, int userId);
}