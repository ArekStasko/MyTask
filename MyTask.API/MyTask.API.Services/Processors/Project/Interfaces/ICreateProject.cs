using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Processors.ProjectProcessors.Interfaces;

public interface ICreateProject
{
    Task<IProject> Execute(IProject project);
}