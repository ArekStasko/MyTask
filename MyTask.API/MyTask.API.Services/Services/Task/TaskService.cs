using AutoMapper;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.Automapper;
using MyTask.API.Services.Services.ProcFactory.TaskProcFactory;
using MyTask.API.DataAccess.Data.Models.Task;

namespace MyTask.API.Services.Services.TaskControllers;

public class TaskService : ITaskService
{
    private readonly ITaskProcFactory _ProcessorFactory;
    private readonly IMapper _mapper;
    
    public TaskService()
    {
        _ProcessorFactory = new TaskProcFactory();
        _mapper = Mapping.Mapper;
    }

    public async Task<TaskDTO> Create(TaskDTO taskDTO)
    {
        var task = _mapper.Map<ITask>(taskDTO);
        var processor = _ProcessorFactory.GetCreateTask();
        var result = await processor.Execute(task);
        taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var processor = _ProcessorFactory.GetDeleteTask();
        var result = await processor.Execute(id);
        return result;
    }

    public async Task<TaskDTO> Update(TaskDTO taskDTO)
    {
        var task = _mapper.Map<ITask>(taskDTO);
        var processor = _ProcessorFactory.GetUpdateTask();
        var result = await processor.Execute(task);
        taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }

    public async Task<List<TaskDTO>> Get(int projectId)
    {
        var processor = _ProcessorFactory.GetGetTasks();
        var result = await processor.Execute(projectId);
        var taskDTOs = _mapper.Map<List<TaskDTO>>(result);
        return taskDTOs;
    }

    public async Task<TaskDTO> GetSingle(int id)
    {
        var processor = _ProcessorFactory.GetGetSingleTask();
        var result = await processor.Execute(id);
        var taskDTO = _mapper.Map<TaskDTO>(result);
        return taskDTO;
    }
}