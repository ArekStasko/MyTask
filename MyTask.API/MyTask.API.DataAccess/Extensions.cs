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
    public static void AddDataContext(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer("Server=mssql-server,1433;Database=MyTask_DB;User Id=sa;Password=Password.1234;TrustServerCertificate=true");
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