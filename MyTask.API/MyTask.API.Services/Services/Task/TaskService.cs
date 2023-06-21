using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.TaskProcFactory;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.TaskControllers;

public class TaskService : ITaskService
{
    private readonly ITaskProcFactory _processorFactory;
    private readonly IMapper _mapper;
    
    public TaskService(ITaskProcFactory taskProcFactory, IMapper mapper)
    {
        _processorFactory = taskProcFactory;
        _mapper = mapper;
    }

    public async Task<TaskDTO> Create(TaskDTO taskDTO, int userId)
    {
        ITask task = _mapper.Map<_Task>(taskDTO);
        var processor = _processorFactory.GetCreateTask();
        var result = await processor.Execute(task, userId);
        taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        var processor = _processorFactory.GetDeleteTask();
        var result = await processor.Execute(id, userId);
        return result;
    }

    public async Task<TaskDTO> Update(TaskDTO taskDTO, int userId)
    {
        var task = _mapper.Map<_Task>(taskDTO);
        var processor = _processorFactory.GetUpdateTask();
        var result = await processor.Execute(task, userId);
        taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }

    public async Task<List<TaskDTO>> Get(int projectId, int userId)
    {
        var processor = _processorFactory.GetGetTasks();
        var result = await processor.Execute(projectId, userId);
        var taskDTOs = _mapper.Map<List<TaskDTO>>(result);
        return taskDTOs;
    }

    public async Task<TaskDTO> GetSingle(int id, int userId)
    {
        var processor = _processorFactory.GetGetSingleTask();
        var result = await processor.Execute(id, userId);
        var taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }
}