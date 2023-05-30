using MyTask.API.Services.Processors.TaskProcessors.Interfaces;

namespace MyTask.API.Services.Services.ProcFactory.TaskProcFactory;

public interface ITaskProcFactory
{
    ICreateTask GetCreateTask();
    IDeleteTask GetDeleteTask();
    IUpdateTask GetUpdateTask();
    IGetTasks GetGetTasks();
    IGetSingleTask GetGetSingleTask();
}