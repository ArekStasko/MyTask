using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Repositories.ProjectRepository;
using MyTask.API.DataAccess.Repositories.RaportRepository;
using MyTask.API.DataAccess.Repositories.TaskRepository;

namespace MyTask.API.DataAccess;

public static class DataExtensions
{
    public static void AddDataContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IRaportRepository, RaportRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
    }

    public static void Migrate(IApplicationBuilder app) => DatabaseMigrationService.MigrationInitialization(app);
    
}