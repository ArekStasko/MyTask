using MyTask.API.DataAccess.Data.Models.Project;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Processors.RaportProcessors.Interfaces;

public interface IGenerateRaport
{
    Task<IRaport> Execute(int projectId);
}