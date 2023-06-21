using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.Services.Processors.ProjectProcessors.Interfaces;

public interface IGetSingleProject
{
    Task<IProject> Execute(int id, int userId);
}