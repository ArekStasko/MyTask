using System.Data;
using MyTask.API.DataAccess.Data.Enums;
using MyTask.API.Services.Processors.RaportProcessors.Interfaces;
using MyTask.API.DataAccess.Data.Models.Raport;
using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.Services.Processors.RaportProcessors;

public class GenerateRaport : IGenerateRaport
{
    private IRaportRepository _raportRepository;
    private ITaskRepository _taskRepository;
    private IProjectRepository _projectRepository;

    public GenerateRaport(IRaportRepository raportRepository, ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _raportRepository = raportRepository;
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<IRaport> Execute(int projectId, string userId)
    {
        try
        {
            var tasks = await _taskRepository.Get(projectId, userId);
            var project = await _projectRepository.Get(projectId, userId);

            if (tasks.Count == 0)
                throw new NoNullAllowedException($"There is no tasks related to {projectId} project");
            
            var openTasks = tasks.Where(t => t.State == TaskState.Open).ToList();
            var inProgressTasks = tasks.Where(t => t.State == TaskState.InProgress).ToList();
            var doneTasks = tasks.Where(t => t.State == TaskState.Done).ToList();
            
            var raport = new Raport()
            {
                RaportName = $"{project.Name} Raport",
                OpenTasks = openTasks.Count,
                InProgressTasks = inProgressTasks.Count,
                DoneTasks = doneTasks.Count
            };
                raport.UserId = userId;
                await _raportRepository.Generate(raport, userId);
                var generatedRaport = await _raportRepository.Get(raport.Id, userId);
                return generatedRaport;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}