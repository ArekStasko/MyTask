using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;

namespace MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;

public interface IProjectProcFactory
{
    ICreateProject GetCreateProject();
    IDeleteProject GetDeleteProject();
    IGetProjects GetGetProjects();
    IGetSingleProject GetGetSingleProject();
}