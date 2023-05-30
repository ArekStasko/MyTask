using MyTask.API.Services.DTO;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.TaskControllers;

public interface ITaskService
{
    Task<TaskDTO> Create(TaskDTO taskDTO);
    Task<bool> Delete(int id);
    Task<TaskDTO> Update(TaskDTO taskDTO);
    Task<List<TaskDTO>> Get(int projectId);
    Task<TaskDTO> GetSingle(int id);
}