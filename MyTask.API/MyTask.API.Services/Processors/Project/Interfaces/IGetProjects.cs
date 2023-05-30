using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Processors.ProjectProcessors.Interfaces;

public interface IGetProjects
{
    Task<List<IProject>> Execute();
}