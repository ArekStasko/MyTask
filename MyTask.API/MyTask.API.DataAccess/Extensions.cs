using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTask.API.DataAccess.Data;

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

    public static void Migrate(IApplicationBuilder app) => DatabaseMigrationService.MigrationInitialization(app);
    
}