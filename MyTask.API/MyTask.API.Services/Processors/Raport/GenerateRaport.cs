using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class GenerateRaport : IGenerateRaport
{
    private IRaportRepository _raportRepository;
    private IProjectRepository _projectRepository;
    private ITaskRepository _taskRepository;

    public GenerateRaport(IRaportRepository repository)
    {
        _raportRepository = repository;
    }

    public async Task<IRaport> Execute(int projectId)
    {
        try
        {
            var openTasksOperation = _taskRepository.Get(projectId);
            var inProgressTasksOperation = _taskRepository.Get(projectId);
            var doneTasksOperation = _taskRepository.Get(projectId);
            
            await Task.WhenAll(new List<Task>() { openTasksOperation, inProgressTasksOperation, doneTasksOperation });

            var openTasks = await openTasksOperation;
            var inProgressTasks = await inProgressTasksOperation;
            var doneTasks = await doneTasksOperation;

            var raport = new Raport()
            {
                OpenTasks = openTasks.Count,
                InProgressTasks = inProgressTasks.Count,
                DoneTasks = doneTasks.Count
            };
                
                await _raportRepository.Generate(raport);
                var generatedRaport = await _raportRepository.Get(raport.Id);
                return generatedRaport;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}