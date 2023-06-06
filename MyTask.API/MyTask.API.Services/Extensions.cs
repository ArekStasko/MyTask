using Microsoft.Extensions.DependencyInjection;
using MyTask.API.Services.Services.ProcFactory.ProjectProcFactory;
using MyTask.API.Services.Services.ProcFactory.RaportProcFactory;
using MyTask.API.Services.Services.ProcFactory.TaskProcFactory;
using MyTask.API.Services.Services.ProjectService;
using MyTask.API.Services.Services.ProjectServices;
using MyTask.API.Services.Services.RaportControllers;
using MyTask.API.Services.Services.TaskControllers;

namespace MyTask.API.Services;

public static class ServiceExtensions
{
    public static void AddMappings(this IServiceCollection services) => services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    
    public static void AddProcessors(this IServiceCollection services)
    {
        services.AddScoped<IProjectProcFactory, ProjectProcFactory>();
        services.AddScoped<IRaportProcFactory, RaportProcFactory>();
        services.AddScoped<ITaskProcFactory, TaskProcFactory>();
    }
    public static void AddAPIServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IRaportService, RaportService>();
        services.AddScoped<ITaskService, TaskService>();
    }
}