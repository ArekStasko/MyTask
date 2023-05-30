using MyTask.API.Services.Processors.ProjectProcessors.Interfaces;
using MyTask.API.DataAccess.Repositories.ProjectRepository;

namespace MyTask.API.Services.Processors.ProjectProcessors;

public class DeleteProject : IDeleteProject
{
    private IProjectRepository _repository;

    public DeleteProject(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Execute(int id)
    {
        try
        {
            var result = await _repository.Delete(id);
            return result;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}